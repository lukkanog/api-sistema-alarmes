using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treetech.Alarms.WebApi.Models;

namespace Treetech.Alarms.WebApi.Interfaces
{
    public interface IEquipamentoRepository
    {

        /// <summary>
        /// Cadastra um novo equipamento no banco de dados.
        /// </summary>
        /// <param name="equipamento">Equipamento a ser cadastrado.</param>
        /// <returns>Equipamento cadastrado.</returns>
        public Task<Equipamento> Cadastrar(Equipamento equipamento);
        
        /// <summary>
        /// Lista todos os equipamentos presentes no banco de dados.
        /// </summary>
        /// <returns>Lista de equipamentos.</returns>
        public Task<List<Equipamento>> Listar();

        /// <summary>
        /// Edita um equipamento específico no banco de dados.
        /// </summary>
        /// <param name="equipamento">Equipamento alterado a ser salvo no banco de dados.</param>
        /// <returns>Equipamento editado.</returns>
        public Task<Equipamento> Editar(Equipamento equipamento);

        /// <summary>
        /// Exclui um equipamento do Banco de Dados.
        /// </summary>
        /// <param name="id">Id do equipamento a ser excluído</param>
        /// <returns>Equipamento excluído</returns>
        public Task<Equipamento> Excluir(int id);
    }
}
