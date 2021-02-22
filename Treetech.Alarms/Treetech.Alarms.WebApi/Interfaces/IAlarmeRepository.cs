using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treetech.Alarms.WebApi.Models;

namespace Treetech.Alarms.WebApi.Interfaces
{
    public interface IAlarmeRepository
    {
        /// <summary>
        /// Cadastra um novo alarme no banco de dados.
        /// </summary>
        /// <param name="alarme">Alarme a ser cadastrado.</param>
        /// <returns>Alarme cadastrado.</returns>
        public Task<Alarme> Cadastrar(Alarme alarme);

        /// <summary>
        /// Lista todos os alarmes presentes no banco de dados.
        /// </summary>
        /// <returns>Lista de alarmes.</returns>
        public Task<List<Alarme>> Listar();

        /// <summary>
        /// Edita um alarme específico no banco de dados.
        /// </summary>
        /// <param name="alarme">Alarme alterado a ser salvo no banco de dados.</param>
        /// <returns>Alarme editado.</returns>
        public Task<Alarme> Editar(Alarme alarme);

        /// <summary>
        /// Exclui um alarme do Banco de Dados.
        /// </summary>
        /// <param name="id">Id do alarme a ser excluído</param>
        /// <returns>Alarme excluído</returns>
        public Task<Alarme> Excluir(int id);
    }
}
