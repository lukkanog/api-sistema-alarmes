using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Treetech.Alarms.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Treetech.Alarms.WebApi.Contexts;
using Treetech.Alarms.WebApi.Repositories;
using Treetech.Alarms.WebApi.Models;

namespace Treetech.Alarms.XUnit.Tests.Repositories
{
    public class EquipamentoRepositoryTest
    {
        private IEquipamentoRepository equipamentoRepository { get; set; }
        public EquipamentoRepositoryTest()
        {
            var builder = new DbContextOptionsBuilder<AlarmsContext>();
            builder.UseInMemoryDatabase("db_Alarms");

            AlarmsContext context = new AlarmsContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            equipamentoRepository = new EquipamentoRepository(context);
        }

        [Fact]
        public async void TestaCadastrarEquipamento()
        {
            var equipamento = new Equipamento()
            {
                NomeEquipamento = "Equipamento teste",
                NumeroSerie = "999999",
                IdTipo = 1
            };

            Equipamento equipamentoCadastrado = await equipamentoRepository.Cadastrar(equipamento);

            Assert.NotNull(equipamentoCadastrado);
            Assert.Equal(equipamentoCadastrado, equipamento);
        }

        [Fact]
        public async void TestaListarEquipamentos()
        {
            var list = await equipamentoRepository.Listar();

            Assert.NotNull(list);
            Assert.Empty(list);
        }

        [Fact]
        public async void TestaEditarEquipamento()
        {
            var equipamento = new Equipamento()
            {
                NomeEquipamento = "Equipamento teste",
                NumeroSerie = "999999",
                IdTipo = 1
            };

            var equipamentoCadastrado = await equipamentoRepository.Cadastrar(equipamento);

            equipamentoCadastrado.NomeEquipamento = "novo nome";
            equipamentoCadastrado.IdTipo = 2;
            equipamentoCadastrado.NumeroSerie = "0";

            var equipamentoEditado = await equipamentoRepository.Editar(equipamentoCadastrado);

            Assert.NotNull(equipamentoEditado);
            Assert.Equal("novo nome", equipamentoEditado.NomeEquipamento);
            Assert.Equal(2, equipamentoEditado.IdTipo);
            Assert.Equal("0", equipamentoEditado.NumeroSerie);

        }

        [Fact]
        public async void TestaExcluirEquipamento()
        {
            var equipamento = new Equipamento()
            {
                NomeEquipamento = "Equipamento teste",
                NumeroSerie = "999999",
                IdTipo = 1
            };

            var equipamentoCadastrado = await equipamentoRepository.Cadastrar(equipamento);

            var equipamentoExcluido = await equipamentoRepository.Excluir(equipamentoCadastrado.IdEquipamento);

            Assert.NotNull(equipamentoExcluido);
            Assert.Equal(equipamentoCadastrado, equipamentoExcluido);
        }

    }
}
