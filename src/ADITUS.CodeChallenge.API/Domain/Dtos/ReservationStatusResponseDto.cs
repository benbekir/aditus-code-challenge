namespace ADITUS.CodeChallenge.API.Domain.Dtos;

public class ReservationStatusResponseDto
{
  /// <summary>
  /// Whether the request is reservation request is accepted.
  /// </summary>
  public bool IsRequestAccepted { get; set; }

  /// <summary>
  /// The name and quantity of the requested hardware components.
  /// </summary>
  public required Dictionary<string, int> RequestedHardwareComponents { get; set; }
}