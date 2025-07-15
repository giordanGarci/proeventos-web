using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using System.Linq;

namespace ProEventos.Persistence;

    public class ProEventosPersistence : IProEventosPersistence
    {
        private readonly ProEventosContext _context;
        public ProEventosPersistence(ProEventosContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entities) where T : class
        {
            _context.RemoveRange(entities);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialMedias);

            if (includeSpeakers)
            {
                query = query.Include(e => e.SpeakerEvents)
                            .ThenInclude(se => se.Speaker);
            }

            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }

    public async Task<Event?> GetAllEventsByIdAsync(int eventId, bool includeSpeakers = false)
    {
        IQueryable<Event> query = _context.Events
            .Include(e => e.Batches)
            .Include(e => e.SocialMedias);

        if (includeSpeakers)
        {
            query = query.Include(e => e.SpeakerEvents)
                        .ThenInclude(se => se.Speaker);
        }
        query = query.Where(e => e.Id == eventId);
        return await query.FirstOrDefaultAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
            {
            IQueryable<Event> query = _context.Events
                .Include(e => e.Batches)
                .Include(e => e.SocialMedias);        

            if (includeSpeakers)
            {
                query = query.Include(e => e.SpeakerEvents)
                            .ThenInclude(se => se.Speaker);
            }
            
            query = query.Where(e => e.Theme.ToLower().Contains(theme.ToLower())); 
            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
            }

        public async Task<Speaker?> GetSpeakerByIdAsync(int speakerId, bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                .Include(s => s.SocialMedias);
            
            if (includeEvents)
            {
                query = query.Include(s => s.SpeakerEvents)
                            .ThenInclude(se => se.Event);
            }
            query = query.Where(s => s.Id == speakerId);
            return await query.FirstOrDefaultAsync();
        }

    public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false)
    {
        IQueryable<Speaker> query = _context.Speakers
            .Include(s => s.SocialMedias);
        if (includeEvents)
        {
            query = query.Include(s => s.SpeakerEvents)
                        .ThenInclude(se => se.Event);
        }
        query = query.OrderBy(s => s.Id);
        return await query.ToArrayAsync();
    }

    public async Task<Speaker[]> GetAllSpeakersByNameAsync(string name, bool includeEvents = false)
    {
        IQueryable<Speaker> query = _context.Speakers
            .Include(s => s.SocialMedias);
        if (includeEvents)
        {
            query = query.Include(s => s.SpeakerEvents)
                        .ThenInclude(se => se.Event);
        }
        query = query.Where(s => s.Name.ToLower().Contains(name.ToLower()));
        query = query.OrderBy(s => s.Id);
        return await query.ToArrayAsync();
        }

}
