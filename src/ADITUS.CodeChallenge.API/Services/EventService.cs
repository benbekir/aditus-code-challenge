using ADITUS.CodeChallenge.API.Domain;

namespace ADITUS.CodeChallenge.API.Services;

public class EventService : IEventService
{
  private readonly IList<Event> m_Events;
  private readonly HttpClient m_HttpClient;

  public EventService()
  {
    m_HttpClient = new HttpClient();
    m_Events = new List<Event>
    {
      new OnSiteEvent
      {
        Id = Guid.Parse("7c63631c-18d4-4395-9c1e-886554265eb0"),
        Year = 2019,
        Name = "ADITUS Code Challenge 2019",
        StartDate = new DateTime(2019, 1, 1),
        EndDate = new DateTime(2019, 1, 31)
      },
      new HybridEvent
      {
        Id = Guid.Parse("751fd775-2c8e-48e0-955c-2144008e984a"),
        Year = 2020,
        Name = "ADITUS Code Challenge 2020",
        StartDate = new DateTime(2020, 1, 1),
        EndDate = new DateTime(2020, 1, 15)
      },
      new OnlineEvent
      {
        Id = Guid.Parse("974098e0-9b3f-41d5-80c2-551600ad204a"),
        Year = 2021,
        Name = "ADITUS Code Challenge 2021",
        StartDate = new DateTime(2021, 1, 1),
        EndDate = new DateTime(2021, 1, 18)
      },
      new OnlineEvent
      {
        Id = Guid.Parse("28669572-2b9a-4b2c-ad7e-6434ea8ab761"),
        Year = 2022,
        Name = "ADITUS Code Challenge 2022",
        StartDate = new DateTime(2022, 1, 1),
        EndDate = new DateTime(2022, 1, 11)
      },
      new OnSiteEvent
      {
        Id = Guid.Parse("3a17b294-8716-448c-94db-ebf9bf53f1ce"),
        Year = 2023,
        Name = "ADITUS Code Challenge 2023",
        StartDate = new DateTime(2023, 1, 1),
        EndDate = new DateTime(2023, 1, 23)
      }
    };
  }

  public Task<Event?> GetEvent(Guid id)
  {
    var @event = m_Events.FirstOrDefault(e => e.Id == id);
    return Task.FromResult(@event);
  }

  public Task<IList<Event>> GetEvents()
  {
    return Task.FromResult(m_Events);
  }

  public async Task<OnlineEventInfo> GetOnlineEventInfoAsync(Guid eventId)
  {
    var response = await m_HttpClient.GetAsync($"https://codechallenge-statistics.azurewebsites.net/api/online-statistics/{eventId}");
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadFromJsonAsync<OnlineEventInfo>()
      ?? throw new InvalidDataException("Failed to deserialize the data.");
  }

  public async Task<OnSiteEventInfo> GetOnSiteEventInfoAsync(Guid eventId)
  {
    var response = await m_HttpClient.GetAsync($"https://codechallenge-statistics.azurewebsites.net/api/onsite-statistics/{eventId}");
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadFromJsonAsync<OnSiteEventInfo>()
      ?? throw new InvalidDataException("Failed to deserialize the data.");
  }
}