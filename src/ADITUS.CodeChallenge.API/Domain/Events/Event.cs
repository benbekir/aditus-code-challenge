namespace ADITUS.CodeChallenge.API.Domain.Events;

/// <summary>
/// Represents an event.
/// </summary>
/// <param name="Type">The type of the event.</param>
public abstract record Event(EventType Type)
{
  /// <summary>
  /// The event id.
  /// </summary>
  public Guid Id { get; init; }

  /// <summary>
  /// The year in which the event is held.
  /// </summary>
  public int Year { get; init; }

  /// <summary>
  /// The name of the event.
  /// </summary>
  public required string Name { get; init; }

  /// <summary>
  /// The type of the event.
  /// </summary>
  public EventType Type { get; } = Type;

  /// <summary>
  /// The start date of the event.
  /// </summary>
  public DateTime StartDate { get; init; }

  /// <summary>
  /// The end date of the event.
  /// </summary>
  public DateTime EndDate { get; init; }
}