using AutoMapper;
using ListaTarefa.Domain.DTOs;
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
        private readonly IMapper _mapper;

        public TarefaController(ITarefaService tarefaService, IMapper mapper)
        {
            _tarefaService = tarefaService;
            _mapper = mapper;
        }

        [HttpGet("BuscarTodasTarefas")]
        public ActionResult<List<TarefaDTO>> GetAll()
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                var tarefas = _tarefaService.GetAll();
                var tarefaDTO = _mapper.Map<List<TarefaDTO>>(tarefas);
                return Ok(tarefaDTO);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("BuscarTarefaById/{id}")]
        public ActionResult<TarefaDTO> GetById(int id)
        {
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                var tarefa = _tarefaService.GetById(id);
                if (tarefa == null)
                    return NotFound("Tarefa não encontrada.");

                var tarefaDTO = _mapper.Map<TarefaDTO>(tarefa);
                
                return Ok(tarefa);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("AdicionarTarefa")]
        public IActionResult Add([FromBody] TarefaDTO tarefa)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var tarefaSave = _mapper.Map<Tarefa>(tarefa);
                _tarefaService.Add<TarefaValidator>(tarefaSave);

                return Ok(new { Message = "Tarefa Criada com sucesso" });
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("AtualizarTarefa")]
        public IActionResult Update([FromBody] TarefaDTO tarefa)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var _tarefa = _mapper.Map<Tarefa>(tarefa);
                _tarefaService.Update<TarefaValidator>(_tarefa);
                return Ok(new { Message = "Tarefa Atualizada com sucesso!" });
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
                return Ok(new { Message = "Tarefa deletada com sucesso!" });
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

        [HttpGet("BuscarTarefaDiaHoje")]
        public IActionResult GetTarefaDiaHoje()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var tarefas = _tarefaService.GetTarefaDiaHoje();

                return Ok(tarefas);
            }
            catch (System.Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
