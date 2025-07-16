using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Application.Interfaces;

public interface IEventService
{
    Task<Event> AddEvents(Event eventToAdd);
    Task<Event?> UpdateEvents(int eventId, Event eventToUpdate);
    Task<bool?> DeleteEvents(int eventId);
    
    Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);
    Task<Event?> GetEventByIdAsync(int eventId, bool includeSpeakers = false);
    Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);
}