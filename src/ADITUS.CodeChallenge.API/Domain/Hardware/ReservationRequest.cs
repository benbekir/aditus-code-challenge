using ADITUS.CodeChallenge.API.Domain.Events;

namespace ADITUS.CodeChallenge.API.Domain.Hardware;

/// <summary>
/// A hardware reservation request for one or multiple components over a specified time span.
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
  /// Whether the request is granted.
  /// </summary>
  public bool IsGranted { get; set; }

  /// <summary>
  /// Start of the reservation.
  /// </summary>
  public DateTime StartOfReservation { get; init; }

  /// <summary>
  /// End of the reservation.
  /// </summary>
  public DateTime EndOfReservation { get; init; }

  /// <summary>
  /// The requested hardware components.
  /// </summary>
  public required List<Hardware> RequestedHardware { get; init; }
}
