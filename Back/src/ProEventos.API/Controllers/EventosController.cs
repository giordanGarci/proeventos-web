using Microsoft.AspNetCore.Mvc;
using ProEventos.Persistence;
using ProEventos.Domain;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly ProEventosContext _context;
    public EventosController(ProEventosContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetEvento")]
    public IEnumerable<Event> Get()
    {
        return _context.Events.ToList();
    }

    [HttpGet("{id}", Name = "GetEventoById")]
    public Event Get(int id)
    {
        return _context.Events.FirstOrDefault(x => x.Id == id);
    }

    [HttpPost(Name = "PostEvento")]
    public string Post()
    {
        return "exemplo de post";
    }
}
