using apiToDo.DTO;
using apiToDo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace apiToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {
        // [Authorize]
        [HttpGet("lstTarefas")]
        public ActionResult lstTarefas()
        {
            try
            {
                var tarefas = new Tarefas().lstTarefas();
                return Ok(tarefas);
            }

            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Ocorreu um erro em sua API {ex.Message}"});
            }
        }

        [HttpGet("BuscarTarefa")]
        public ActionResult BuscarTarefa([FromQuery] int ID_TAREFA)
        {
            try
            {
                var tarefa = new Tarefas().BuscarTarefa(ID_TAREFA);
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Ocorreu um erro ao buscar tarefa: {ex.Message}" });
            }
        }

        [HttpPost("InserirTarefas")]
        public ActionResult InserirTarefas([FromBody] TarefaDTO Request)
        {
            try
            {
                var tarefas = new Tarefas().InserirTarefa(Request);
                return Ok(tarefas);


            }

            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Ocorreu um erro em sua API: {ex.Message}" });
            }
        }

        [HttpPut("AtualizarTarefa")]
        public ActionResult AtualizarTarefa([FromBody] TarefaDTO Request)
        {
            try
            {
                var tarefas = new Tarefas().AtualizarTarefa(Request);
                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Ocorreu um erro ao atualizar tarefa: {ex.Message}" });
            }
        }

        [HttpDelete("DeletarTarefa")]
        public ActionResult DeleteTask([FromQuery] int ID_TAREFA)
        {
            try
            {
                var tarefas = new Tarefas().DeletarTarefa(ID_TAREFA);
                return Ok(tarefas); // retorna list atualizada
            }

            catch (Exception ex)
            {
                return BadRequest(new { msg = $"Ocorreu um erro ao deletar tarefa: {ex.Message}" });
            }
        }
    }
}
