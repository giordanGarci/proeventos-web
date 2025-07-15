using ProEventos.Domain;
using System.Threading.Tasks;

namespace ProEventos.Persistence;

public interface IProEventosPersistence
{
    // Geral
    void Add<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    void DeleteRange<T>(T[] entities) where T : class;
    Task<bool> SaveChangesAsync();

    // Eventos
    Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);
    Task<Event?> GetAllEventsByIdAsync(int eventId, bool includeSpeakers = false);

    Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);

    // Speakers
    Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false);
    Task<Speaker?> GetSpeakerByIdAsync(int speakerId, bool includeEvents = false);
    Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents = false);
}