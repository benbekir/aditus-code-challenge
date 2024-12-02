namespace ADITUS.CodeChallenge.API.Domain.Events;

/// <summary>
/// Represents an event that is held on site only.
/// </summary>
public record OnSiteEvent() : Event(EventType.OnSite)
{
  /// <summary>
  /// Additional on site information.
  /// </summary>
  public OnSiteEventInfo? OnSiteInfo { get; set; }
}
