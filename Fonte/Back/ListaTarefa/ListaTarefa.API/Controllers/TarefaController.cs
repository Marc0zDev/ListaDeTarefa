using ListaTarefa.Domain.Entities;
using ListaTarefa.Domain.Enums;
using ListaTarefa.Domain.Interfaces.IServices;
using ListaTarefa.Service.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ListaTarefa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet("BuscarTodasTarefas")]
        public IActionResult GetAll()
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                var tarefas = _tarefaService.GetAll();
                return Ok(tarefas);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("BuscarTarefaById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                var tarefa = _tarefaService.GetById(id);
                if (tarefa == null)
                    return NotFound("Tarefa não encontrada.");

                return Ok(tarefa);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("AdicionarTarefa")]
        public IActionResult Add([FromBody] Tarefa tarefa)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _tarefaService.Add<TarefaValidator>(tarefa);
                return Ok("Tarefa adicionada com sucesso!");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("AtualizarTarefa")]
        public IActionResult Update([FromBody] Tarefa tarefa)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _tarefaService.Update<TarefaValidator>(tarefa);
                return Ok("Tarefa atualizada com sucesso!");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeletarTarefa/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _tarefaService.Delete(id);
                return Ok("Tarefa deletada com sucesso!");
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("BuscarTarefaByStatus/{status}")]
        public IActionResult GetTarefaByStatus(int status)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                StatusTarefa statusTarefa = (StatusTarefa)status;
                var tarefas = _tarefaService.GetTarefaByStatus(statusTarefa);
                return Ok(tarefas);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
