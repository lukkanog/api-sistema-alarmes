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
    public class EquipamentosController : ControllerBase
    {
        private static IEquipamentoRepository equipamentoRepository { get; set; }

        public EquipamentosController()
        {
            equipamentoRepository = new EquipamentoRepository();
        }


        [HttpPost]
        public async Task<IActionResult> CadastrarEquipamento(Equipamento equipamento)
        {
            try
            {
                var equipamentocadastrado = await equipamentoRepository.Cadastrar(equipamento);
                return Ok(equipamentocadastrado);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListarEquipamenetos()
        {
            try
            {
                var list = await equipamentoRepository.Listar();
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditarEquipamento(Equipamento equipamento)
        {
            try
            {
                var equipamentoEditado = await equipamentoRepository.Editar(equipamento);
                return Ok(equipamentoEditado);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpDelete("{idEquipamento}")]
        public async Task<IActionResult> ExcluirEquipamento(int idEquipamento)
        {
            try
            {
                var equipamentoExcluido = await equipamentoRepository.Excluir(idEquipamento);
                return Ok(equipamentoExcluido);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

    }
}
