using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Interfaces;

public interface IEventPersist
{
    Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);
    Task<Event?> GetEventByIdAsync(int eventId, bool includeSpeakers = false);
    Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);

}