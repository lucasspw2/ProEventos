using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;


namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{

  public IEnumerable<Evento> _evento = new Evento[]{
        new Evento {
          EventoId = 1,
          Tema = "Angular 11 e .NET 6",
          Local = "Belo horizonte",
          Lote = "1º Lote",
          QtdPessoas = 250,
          DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
          ImagemURL = "Foto.png"
        },    
        new Evento {
          EventoId = 2,
          Tema = "Angular 11 e .NET 6",
          Local = "Belo horizonte2",
          Lote = "1º Lote2",
          QtdPessoas = 2502,
          DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
          ImagemURL = "Foto.png2"
        }  
      };

  [HttpGet]
    public IEnumerable<Evento> Get()
    {
      return _evento;
    }

      [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {

      return _evento.Where(evento => evento.EventoId == id);
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
