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

        public Task<Equipamento> Editar(Equipamento equipamento)
        {
            throw new NotImplementedException();
        }

        public Task<Equipamento> Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Equipamento>> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
