using ADITUS.CodeChallenge.API.Domain;
using ADITUS.CodeChallenge.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ADITUS.CodeChallenge.API.Controllers;

[Route("events")]
public class EventsController : ControllerBase
{
  private readonly IEventService m_EventService;

  public EventsController(IEventService eventService)
  {
    m_EventService = eventService;
  }

  [HttpGet]
  [Route("")]
  public async Task<IActionResult> GetEvents()
  {
    var events = await m_EventService.GetEvents();
    return Ok(events);
  }

  [HttpGet]
  [Route("{id}")]
  public async Task<IActionResult> GetEvent(Guid id)
  {
    var @event = await m_EventService.GetEvent(id);
    if (@event is null)
    {
      return NotFound();
    }

    if (@event is OnSiteEvent onSiteEvent)
    {
      onSiteEvent.OnSiteInfo = await m_EventService.GetOnSiteEventInfoAsync(id);
      return Ok(onSiteEvent);
    }
    if (@event is OnlineEvent onlineEvent)
    {
      onlineEvent.OnlineInfo = await m_EventService.GetOnlineEventInfoAsync(id);
      return Ok(onlineEvent);
    }
    if (@event is HybridEvent hybridEvent)
    {
      hybridEvent.OnSiteInfo = await m_EventService.GetOnSiteEventInfoAsync(id);
      hybridEvent.OnlineInfo = await m_EventService.GetOnlineEventInfoAsync(id);
      return Ok(hybridEvent);
    }

    return Ok(@event);
  }
}