namespace ADITUS.CodeChallenge.API.Domain;

public record OnlineEvent() : Event(EventType.Online)
{
  public OnlineEventInfo? OnlineInfo { get; set; }
}
