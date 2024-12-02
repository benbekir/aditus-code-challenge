namespace ADITUS.CodeChallenge.API.Domain.Events;

/// <summary>
/// Represents an event that is held online only.
/// </summary>
public record OnlineEvent() : Event(EventType.Online)
{
  /// <summary>
  /// Additional online information.
  /// </summary>
  public OnlineEventInfo? OnlineInfo { get; set; }
}
