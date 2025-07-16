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
    public string Post()
    {
        return "exemplo de post";
    }
}
