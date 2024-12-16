using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;


namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{


      private readonly IEventoService _eventoService;

      public EventosController(IEventoService eventoService)
      {
            _eventoService = eventoService;
            
      }

  [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
          var Eventos = await _eventoService.GetAllEventosAsync(true);
          if(Eventos == null) return NotFound("nenhum evento encontrado");
          return Ok(Eventos);
      }
      catch (Exception ex)
      {
        
        return StatusCode(StatusCodes.Status500InternalServerError, 
        $"erro ao tentar recuperar eventos. Erro{ex.Message}");
      }
    
    }

      [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      try
      {
          var Evento = await _eventoService.GetEventoByIdAsync(id, true);
          if(Evento == null) return NotFound("evento por id não encontrado");
          return Ok(Evento);
      }
      catch (Exception ex)
      {
        
        return StatusCode(StatusCodes.Status500InternalServerError, 
        $"erro ao tentar recuperar eventos. Erro{ex.Message}");
      }
    }


   [HttpGet("{tema}/tema")]
    public async Task<IActionResult> GetByTema(string tema)
    {
      try
      {
          var Evento = await _eventoService.GetAllEventosByTemaAsync(tema, true);
          if(Evento == null) return NotFound("eventos por tema não encontrado");
          return Ok(Evento);
      }
      catch (Exception ex)
      {
        
        return StatusCode(StatusCodes.Status500InternalServerError, 
        $"erro ao tentar recuperar eventos. Erro{ex.Message}");
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Evento model)
    {
      try
      {
          var evento = await _eventoService.AddEventos(model);
          if(evento == null) return BadRequest("erro ao adicionar evento");
          return Ok(evento);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, 
        $"erro ao tentar adicionar evento. Erro{ex.Message}");
      }
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Evento model)
    {
      try
      {
          var evento = await _eventoService.UpdateEvento(id, model);
          if(evento == null) return BadRequest("erro ao tentar atualizar evento");
          return Ok(evento);
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, 
        $"erro ao tentar atualizar evento. Erro{ex.Message}");
      }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
         return await _eventoService.DeleteEvento(id) ?
          Ok("Deletado") :
          BadRequest("erro ao tentar deletar evento");
      }
      catch (Exception ex)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, 
        $"erro ao tentar deletar evento. Erro{ex.Message}");
      }
    }
}
