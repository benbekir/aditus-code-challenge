namespace ADITUS.CodeChallenge.API.Domain.Events;

/// <summary>
/// Represents an event that is held both online and on site.
/// </summary>
public record HybridEvent() : Event(EventType.Hybrid)
{
  /// <summary>
  /// Additional information about the online part of the event.
  /// </summary>
  public OnlineEventInfo? OnlineInfo { get; set; }

  /// <summary>
  /// Additional information about the on site part of the event.
  /// </summary>
  public OnSiteEventInfo? OnSiteInfo { get; set; }
}
