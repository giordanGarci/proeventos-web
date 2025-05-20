using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    public IEnumerable<Evento> _evento = new Evento[]{
        new Evento(){
            EventoId = 1,
            Local = "Sao Paulo",
            DataEvento = DateTime.Now.ToString("dd/MM/yyyy"),
            Tema = "Angular 11 e dotnet 6",
            QtdPessoas = 100,
            Lote = "1° lote",
            ImagemURL = "foto.png"
        },
        new Evento(){
            EventoId = 2,
            Local = "BH",
            DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
            Tema = "Papa Leão XIV",
            QtdPessoas = 1500,
            Lote = "2° lote",
            ImagemURL = "imagem.jpeg"
        }
    };

    public EventoController()
    {
    }

    [HttpGet(Name = "GetEvento")]
    public IEnumerable<Evento> Get()
    {
        return _evento;
    }

    [HttpGet("{id}", Name = "GetEventoById")]
    public Evento Get(int id)
    {
        return _evento.FirstOrDefault(x => x.EventoId == id);
    }

    [HttpPost(Name = "PostEvento")]
    public string Post()
    {
        return "exemplo de post";
    }
}
