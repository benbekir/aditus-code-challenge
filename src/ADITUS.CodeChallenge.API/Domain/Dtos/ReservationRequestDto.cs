namespace ADITUS.CodeChallenge.API.Domain.Dtos;

public class ReservationRequestDto
{
  /// <summary>
  /// The event id to make the reservation for.
  /// </summary>
  public Guid EventId { get; set; }

  /// <summary>
  /// The number of turnstiles to reserve.
  /// </summary>
  public int TurnstileCount { get; set; }

  /// <summary>
  /// The number of scanners to reserve.
  /// </summary>
  public int ScannerCount { get; set; }

  /// <summary>
  /// The number of terminals to reserve.
  /// </summary>
  public int TerminalCount { get; set; }
}
