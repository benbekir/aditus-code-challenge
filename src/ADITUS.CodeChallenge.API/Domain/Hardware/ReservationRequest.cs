using ADITUS.CodeChallenge.API.Domain.Events;

namespace ADITUS.CodeChallenge.API.Domain.Hardware;

/// <summary>
/// A hardware reservation request for one or multiple components for the duration of an event.
/// </summary>
public record ReservationRequest
{
  /// <summary>
  /// The id of the reservation request.
  /// </summary>
  public Guid Id { get; init; }

  /// <summary>
  /// The event that the reservation is for.
  /// </summary>
  public required Event Event { get; init; }

  /// <summary>
  /// Whether the request is accepted.
  /// </summary>
  public bool IsAccepted { get; set; }

  /// <summary>
  /// The requested hardware components.
  /// </summary>
  public required List<Hardware> RequestedHardware { get; init; }
}
