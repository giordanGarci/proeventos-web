using System;
using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application;

public class EventService : IEventService
{
    private readonly IBasePersist _geralPersist;
    private readonly IEventPersist _eventPersist;
    public EventService(IBasePersist geralPersist, IEventPersist eventPersist)
    {
        _geralPersist = geralPersist;
        _eventPersist = eventPersist;
    }
    public async Task<Event> AddEvents(Event eventToAdd)
    {
        try
        {
            _geralPersist.Add<Event>(eventToAdd);
            if (await _geralPersist.SaveChangesAsync())
            {
                return await _eventPersist.GetEventByIdAsync(eventToAdd.Id, false);
            }
            return null;
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while adding event: {ex.Message}", ex);
        }
    }

    public async Task<Event?> UpdateEvents(int eventId, Event eventToUpdate)
    {
        try
        {
            var existingEvent = await _eventPersist.GetEventByIdAsync(eventId, false);
            if (existingEvent == null) return null;

            existingEvent.Id = eventToUpdate.Id;
            _geralPersist.Update<Event>(existingEvent);
            if (await _geralPersist.SaveChangesAsync())
            {
                return await _eventPersist.GetEventByIdAsync(eventId, false);
            }
            return null;

        }
        catch (Exception ex)
        {
            throw new Exception($"Error while updating event with ID {eventId}: {ex.Message}", ex);
        }
    }
    public async Task<bool?> DeleteEvents(int eventId)
    {
        try{
            var eventToDelete = await _eventPersist.GetEventByIdAsync(eventId, false)
                ?? throw new Exception($"Event to delete with ID {eventId} not found.");
                
            _geralPersist.Delete<Event>(eventToDelete);
            return await _geralPersist.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Error while deleting event with ID {eventId}: {ex.Message}", ex);
        }
    
    }

    public Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
    {
        throw new NotImplementedException();
    }

    public Task<Event?> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
    {
        throw new NotImplementedException();
    }

    public Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
    {
        throw new NotImplementedException();
    }

}
