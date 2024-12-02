namespace ADITUS.CodeChallenge.API.Domain.Events;

/// <summary>
/// Optional information about an on site event.
/// </summary>
public record OnSiteEventInfo
{
  public int VisitorsCount { get; init; }
  public int ExhibitorsCount { get; init; }
  public int BoothsCount { get; init; }
}
