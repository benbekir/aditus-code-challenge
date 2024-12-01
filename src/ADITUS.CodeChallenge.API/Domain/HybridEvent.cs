namespace ADITUS.CodeChallenge.API.Domain;

public record HybridEvent() : Event(EventType.Hybrid)
{
  public OnlineEventInfo? OnlineInfo { get; set; }
  public OnSiteEventInfo? OnSiteInfo { get; set; }
}
