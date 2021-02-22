using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treetech.Alarms.WebApi.Interfaces;
using Treetech.Alarms.WebApi.Models;
using Treetech.Alarms.WebApi.Repositories;

namespace Treetech.Alarms.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AlarmesAtuadosController : ControllerBase
    {
        private static IAlarmeAtuadoRepository alarmeAtuadoRepository { get; set; }

        public AlarmesAtuadosController()
        {
            alarmeAtuadoRepository = new AlarmeAtuadoRepository();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAlarmeAtuado(AlarmeAtuado alarmeAtuado)
        {
            try
            {
                var alarmeAtuadoCadastrado = await alarmeAtuadoRepository.Cadastrar(alarmeAtuado);
                return Ok(alarmeAtuadoCadastrado);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarAlarmesAtuados()
        {
            try
            {
                var list = await alarmeAtuadoRepository.Listar();
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpPatch("{idAlarmeAtuado}")]
        public async Task<IActionResult> AlterarStatus(int idAlarmeAtuado)
        {
            try
            {
                var itemAlterado = await alarmeAtuadoRepository.AlterarStatus(idAlarmeAtuado);
                return Ok(itemAlterado);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

    }
}
