using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treetech.Alarms.WebApi.Contexts;
using Treetech.Alarms.WebApi.Interfaces;
using Treetech.Alarms.WebApi.Models;

namespace Treetech.Alarms.WebApi.Repositories
{
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private AlarmsContext context { get; set; }

        public EquipamentoRepository()
        {
            context = new AlarmsContext();
        }

        public EquipamentoRepository(AlarmsContext alarmsContext)
        {
            context = alarmsContext;
        }

        public async Task<Equipamento> Cadastrar(Equipamento equipamento)
        {
            equipamento.DataCadastro = DateTime.Now;

            context.Equipamentos.Add(equipamento);
            await context.SaveChangesAsync();

            return equipamento;

        }

        public async Task<Equipamento> Editar(Equipamento equipamento)
        {
            Equipamento toBeEdited = context.Equipamentos.Find(equipamento.IdEquipamento);

            if (toBeEdited == null)
                throw new Exception("Equipamento não encontrado");


            context.Update(equipamento);
            await context.SaveChangesAsync();

            return equipamento;
        }

        public async Task<Equipamento> Excluir(int id)
        {
            Equipamento toBeRemoved = context.Equipamentos.Find(id);

            if (toBeRemoved == null)
                throw new Exception("Equipamento não encontrado");

            context.Remove(toBeRemoved);
            await context.SaveChangesAsync();

            return toBeRemoved;
        }

        public async Task<List<Equipamento>> Listar()
        {
            List<Equipamento> list = context.Equipamentos.ToList();
            return list;
        }
    }
}
