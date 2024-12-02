using ADITUS.CodeChallenge.API.Domain.Dtos;
using ADITUS.CodeChallenge.API.Domain.Hardware;
using ADITUS.CodeChallenge.API.MockData;
using ADITUS.CodeChallenge.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ADITUS.CodeChallenge.API.Controllers;

[ApiController]
[Route("hardware")]
public class HardwareReservationController : ControllerBase
{
  private readonly IEventService m_EventService;
  private readonly object m_Lock = new();

  public HardwareReservationController(IEventService eventService)
  {
    m_EventService = eventService;
  }

  [HttpPost]
  [Route("reserve")]
  public async Task<IActionResult> ReserveHardware([FromBody] ReservationRequestDto request)
  {
    // make sure that there are no existing reservations for the provided event
    var reservationExists = HardwareData.Reservations.Any(x => x.Event.Id.Equals(request.EventId));
    if (reservationExists)
    {
      return BadRequest("Reservation has already been made.");
    }

    // make sure the event exists
    var @event = await m_EventService.GetEvent(request.EventId);
    if (@event is null)
    {
      return BadRequest($"No event found for id {request.EventId}.");
    }

    // reservations must be made at least four weeks before the event starts
    if (DateTime.Now.AddDays(28) >= @event.StartDate)
    {
      return BadRequest("Hardware can only be reserved up to four weeks before the start of the event.");
    }

    lock (m_Lock)
    {
      // check if enough hardware components can be reserved
      List<Hardware> availableHardware = [];
      var missingTurnstiles = request.TurnstileCount;
      var missingScanners = request.ScannerCount;
      var missingTerminals = request.TerminalCount;

      // check for enough turnstiles
      foreach (var turnstile in HardwareData.Turnstiles)
      {
        if (missingTurnstiles > 0 && turnstile.IsAvailableBetween(@event.StartDate, @event.EndDate))
        {
          availableHardware.Add(turnstile);
          missingTurnstiles--;
        }
        if (missingTurnstiles == 0)
        {
          break;
        }
      }
      if (missingTurnstiles > 0)
      {
        return BadRequest("Not enough turnstiles available.");
      }

      // check for enough scanners
      foreach (var scanner in HardwareData.Scanners)
      {
        if (missingScanners > 0 && scanner.IsAvailableBetween(@event.StartDate, @event.EndDate))
        {
          availableHardware.Add(scanner);
          missingScanners--;
        }
        if (missingScanners == 0)
        {
          break;
        }
      }
      if (missingScanners > 0)
      {
        return BadRequest("Not enough scanners available.");
      }

      // check for enough terminals
      foreach (var terminal in HardwareData.Terminals)
      {
        if (missingTerminals > 0 && terminal.IsAvailableBetween(@event.StartDate, @event.EndDate))
        {
          availableHardware.Add(terminal);
          missingTerminals--;
        }
        if (missingTerminals == 0)
        {
          break;
        }
      }
      if (missingTerminals > 0)
      {
        return BadRequest("Not enough terminals available.");
      }

      // reserve all hardware
      var reservationRequest = new ReservationRequest()
      {
        Id = @event.Id,
        Event = @event,
        StartOfReservation = @event.StartDate.AddDays(-1),
        EndOfReservation = @event.EndDate.AddDays(1),
        RequestedHardware = availableHardware
      };
      HardwareData.Reservations.Add(reservationRequest);
      foreach (var hardwareComponent in availableHardware)
      {
        hardwareComponent.Reservations.Add(reservationRequest);
      }
      return Ok(reservationRequest.Id);
    }
  }

  [HttpGet]
  [Route("status/{id}")]
  public IActionResult GetStatus(Guid id)
  {
    var reservation = HardwareData.Reservations.FirstOrDefault(res => res.Id.Equals(id));
    if (reservation is null)
    {
      return BadRequest($"No reservation found for id {id}.");
    }
    var response = new ReservationStatusResponseDto()
    {
      IsRequestGranted = reservation.IsGranted,
      RequestedHardwareComponents = reservation.RequestedHardware.GroupBy(x => x.ToString()).ToDictionary(x => x.Key!, x => x.Count())
    };
    return Ok(response);
  }
}