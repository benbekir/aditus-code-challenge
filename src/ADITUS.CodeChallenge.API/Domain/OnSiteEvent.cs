namespace ADITUS.CodeChallenge.API.Domain;

public record OnSiteEvent() : Event(EventType.OnSite)
{
  public OnSiteEventInfo? OnSiteInfo { get; set; }
}
