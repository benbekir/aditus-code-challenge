namespace ADITUS.CodeChallenge.API.Domain;

public record OnSiteEventInfo
{
  public int VisitorsCount { get; init; }
  public int ExhibitorsCount { get; init; }
  public int BoothsCount { get; init; }
}
