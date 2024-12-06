using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;


namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{


      private readonly DataContext _context;

      public EventoController(DataContext context)
      {
            _context = context;
        
      }

  [HttpGet]
    public IEnumerable<Evento> Get()
    {
      return _context.Eventos;
    }

      [HttpGet("{id}")]
    public Evento GetById(int id)
    {

      return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
    }

    


    [HttpPost]
    public string Post(string id)
    {
      return $"value2222 {id}";
    }

    
    [HttpPut("{id}")]
    public string Put(string id)
    {
      return $"value2222 {id}";
    }
}
