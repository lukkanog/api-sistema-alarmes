using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treetech.Alarms.WebApi.Contexts;
using Treetech.Alarms.WebApi.Interfaces;
using Treetech.Alarms.WebApi.Models;

namespace Treetech.Alarms.WebApi.Repositories
{
    public class AlarmeRepository : IAlarmeRepository
    {
        private AlarmsContext context { get; set; }

        public AlarmeRepository()
        {
            context = new AlarmsContext();
        }

        //to create in memory repository (for test purporses)
        public AlarmeRepository(AlarmsContext alarmsContext)
        {
            context = alarmsContext;
        }

        public async Task<Alarme> Cadastrar(Alarme alarme)
        {
            alarme.DataCadastro = DateTime.Now;

            context.Alarmes.Add(alarme);
            await context.SaveChangesAsync();

            return alarme;
        }

        public async Task<List<Alarme>> Listar()
        {
            var list = context.Alarmes.ToList();
            return list;
        }

        public async Task<Alarme> Editar(Alarme alarme)
        {
            var toBeEdited = context.Alarmes.Find(alarme.IdAlarme);

            if (toBeEdited == null)
                throw new Exception("Alarme não encontrado");

            toBeEdited.Descricao = alarme.Descricao;
            toBeEdited.IdClassificacao = alarme.IdClassificacao;
            toBeEdited.IdEquipamento = alarme.IdEquipamento;

            context.Update(toBeEdited);
            await context.SaveChangesAsync();

            return toBeEdited;
        }

        public async Task<Alarme> Excluir(int id)
        {
            Alarme toBeRemoved = context.Alarmes.Find(id);

            if (toBeRemoved == null)
                throw new Exception("Alarme não encontrado");

            context.Alarmes.Remove(toBeRemoved);
            await context.SaveChangesAsync();
            return toBeRemoved;
        }
    }
}
