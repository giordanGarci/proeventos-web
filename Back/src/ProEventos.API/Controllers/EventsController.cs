using Microsoft.AspNetCore.Mvc;
using ProEventos.Persistence;
using ProEventos.Domain;
using System;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;
    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet(Name = "GetEvento")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var events = _eventService.GetAllEventsAsync(true);
            if (events == null || !events.Any())
            {
                return NotFound("No events found.");
            }
            return Ok(events);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error retrieving events: {ex.Message}");
        }
    }

    [HttpGet("{id}", Name = "GetEventoById")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var eventById = await _eventService.GetEventByIdAsync(id, true);
            if (eventById == null) return NotFound($"Event by id not found. Id {id}");
            return Ok(eventById);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error retrieving event with ID {id}: {ex.Message}");
        }

    }

    [HttpGet("theme/{theme}", Name = "GetEventoByTheme")]
    public async Task<IActionResult> GetByTheme(string theme)
    {
        try
        {
            var eventsByTheme = await _eventService.GetAllEventsByThemeAsync(theme, true);
            if (eventsByTheme == null || !eventsByTheme.Any())
            {
                return NotFound($"No events found by {theme}. Please try another theme.");
            }
            return Ok(eventsByTheme);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error retrieving events by theme '{theme}': {ex.Message}");
        }
    }

    [HttpPost(Name = "PostEvento")]
    public async Task<IActionResult> Post([FromBody] Event eventToAdd)
    {
        try
        {
            var eventToAdd = await _eventService.AddEvents(eventToAdd);
            if (eventToAdd == null) return BadRequest("Event to add is null or invalid.");

            return Ok(eventToAdd);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Error adding event: {ex.Message}");
        }
    }

    [HttpPut(Name = "PutEvento")]
    public async Task<IActionResult> Put(int id, [FromBody] Event eventToUpdate)
    {
        try
        {

            var updatedEvent = await _eventService.UpdateEvents(id, eventToUpdate);
            if (updatedEvent == null) return NotFound($"Event with ID {id} not found.");
            return Ok(updatedEvent);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error updating event with ID {id}: {ex.Message}");
        }
    }

    [HttpDelete(Name = "DeleteEvento")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            return await _eventService.DeleteEvents(id) ?
                Ok("Event deleted successfully.") :
                NotFound($"Event with ID {id} not found.");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
            $"Error deleting event with ID {id}: {ex.Message}");
        }
    }

}
