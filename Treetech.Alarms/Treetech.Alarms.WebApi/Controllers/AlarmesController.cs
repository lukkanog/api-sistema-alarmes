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
    public class AlarmesController : ControllerBase
    {
        private static IAlarmeRepository alarmeRepository { get; set; }

        public AlarmesController()
        {
            alarmeRepository = new AlarmeRepository();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAlarme(Alarme alarme)
        {
            try
            {
                var alarmeCadastrado = await alarmeRepository.Cadastrar(alarme);
                return Ok(alarmeCadastrado);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarAlarmes()
        {
            try
            {
                var list = await alarmeRepository.Listar();
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditarAlarme(Alarme alarme)
        {
            try
            {
                var alarmeEditado = await alarmeRepository.Editar(alarme);
                return Ok(alarmeEditado);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpDelete("{idAlarme}")]
        public async Task<IActionResult> ExcluirAlarme(int idAlarme)
        {
            try
            {
                var alarmeExcluido = await alarmeRepository.Excluir(idAlarme);
                return Ok(alarmeExcluido);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

    }
}
