using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treetech.Alarms.WebApi.Models;

namespace Treetech.Alarms.WebApi.Interfaces
{
    public interface IAlarmeAtuadoRepository
    {
        /// <summary>
        /// Cadastra um novo alarme atuado no banco de dados.
        /// </summary>
        /// <param name="alarmeAtuado">AlarmeAtuado a ser cadastrado.</param>
        /// <returns>AlarmeAtuado cadastrado.</returns>
        public Task<AlarmeAtuado> Cadastrar(AlarmeAtuado alarmeAtuado);

        /// <summary>
        /// Lista todos os alarmes atuados presentes no banco de dados.
        /// </summary>
        /// <returns>Lista de alarmeAtuados.</returns>
        public Task<List<AlarmeAtuado>> Listar();

        /// <summary>
        /// Altera o status do alarme atuado. Se ativo, será desativado e vice-versa.
        /// </summary>
        /// <param name="idAlarme">id do alarme a ser modificado.</param>
        /// <returns>Alarme atuado com status alterado.</returns>
        public Task<AlarmeAtuado> AlterarStatus(int idAlarmeAtuado);


    }
}
