namespace ADITUS.CodeChallenge.API.Domain.Hardware;

/// <summary>
/// Represents a hardware component that can be reserved.
/// </summary>
public abstract class Hardware
{
  /// <summary>
  /// All reservations that are associated to this hardware component.
  /// </summary>
  public List<ReservationRequest> Reservations { get; set; } = [];

  /// <summary>
  /// Whether this hardware component is available to be reserved between <paramref name="startTime"/> and <paramref name="endTime"/>.
  /// </summary>
  /// <param name="startTime">The start of the reservation.</param>
  /// <param name="endTime">The end of the reservation.</param>
  /// <returns></returns>
  public bool IsAvailableBetween(DateTime startTime, DateTime endTime)
  {
    // MOCK IMPLEMENTATION
    // real implementation would check if any reservation exists which start time or end time overlap with the requested ones.
    return true;
  }
}
