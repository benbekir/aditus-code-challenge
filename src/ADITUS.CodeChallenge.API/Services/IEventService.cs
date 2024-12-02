using ADITUS.CodeChallenge.API.Domain.Events;

namespace ADITUS.CodeChallenge.API.Services;

public interface IEventService
{
  /// <summary>
  /// Get an event by id.
  /// </summary>
  /// <param name="id">The event id.</param>
  /// <returns>The event with the given id.</returns>
  Task<Event?> GetEvent(Guid id);

  /// <summary>
  /// Get all events.
  /// </summary>
  /// <returns>All known events.</returns>
  Task<IList<Event>> GetEvents();

  /// <summary>
  /// Get additional information about an online event.
  /// </summary>
  /// <param name="eventId">The event id to get the information for.</param>
  /// <returns>The information about the specified online event.</returns>
  Task<OnlineEventInfo> GetOnlineEventInfoAsync(Guid eventId);

  /// <summary>
  /// Get additional informatino about an on site event.
  /// </summary>
  /// <param name="eventId">The event id to get the information for.</param>
  /// <returns>The information about the specified on site event.</returns>
  Task<OnSiteEventInfo> GetOnSiteEventInfoAsync(Guid eventId);
}