using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treetech.Alarms.WebApi.Contexts;
using Treetech.Alarms.WebApi.Interfaces;
using Treetech.Alarms.WebApi.Models;

namespace Treetech.Alarms.WebApi.Repositories
{
    public class AlarmeAtuadoRepository : IAlarmeAtuadoRepository
    {
        private AlarmsContext context { get; set; }

        public AlarmeAtuadoRepository()
        {
            context = new AlarmsContext();
        }

        //to create in memory repository (for test purporses)
        public AlarmeAtuadoRepository(AlarmsContext alarmsContext)
        {
            context = alarmsContext;
        }


        public async Task<AlarmeAtuado> AlterarStatus(int idAlarmeAtuado)
        {
            var alarmeAtuado = context.AlarmesAtuados.Find(idAlarmeAtuado);

            if (alarmeAtuado == null)
                throw new Exception("Registro de alarme atuado não encontrado.");

            alarmeAtuado.Ativo = !alarmeAtuado.Ativo;

            context.Update(alarmeAtuado);
            await context.SaveChangesAsync();

            return alarmeAtuado;
        }

        public async Task<AlarmeAtuado> Cadastrar(AlarmeAtuado alarmeAtuado)
        {
            alarmeAtuado.Ativo = false;

            context.AlarmesAtuados.Add(alarmeAtuado);
            await context.SaveChangesAsync();

            return alarmeAtuado;
        }

        public async Task<List<AlarmeAtuado>> Listar()
        {
            var list = context.AlarmesAtuados
                .Include(x => x.Alarme)
                .ThenInclude(y => y.Equipamento)
                .ToList();

            //evita loops no JSON de resposta
            foreach (var item in list)
            {
                item.Alarme.AlarmesAtuados = null;
            }

            return list;
        }
    }
}
