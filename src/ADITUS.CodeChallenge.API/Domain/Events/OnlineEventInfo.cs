namespace ADITUS.CodeChallenge.API.Domain.Events;

/// <summary>
/// Optional information about an online event.
/// </summary>
public record OnlineEventInfo
{
  public int Attendees { get; init; }
  public int Invites { get; init; }
  public int Visits { get; init; }
  public int VirtualRooms { get; init; }
}
