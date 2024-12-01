namespace ADITUS.CodeChallenge.API.Domain;

public abstract record Event(EventType Type)
{
  public Guid Id { get; init; }
  public int Year { get; init; }
  public required string Name { get; init; }
  public EventType Type { get; } = Type;
  public DateTime? StartDate { get; init; }
  public DateTime? EndDate { get; init; }
}