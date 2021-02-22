using System;
using Microsoft.EntityFrameworkCore;
using Treetech.Alarms.WebApi.Contexts;
using Treetech.Alarms.WebApi.Interfaces;
using Treetech.Alarms.WebApi.Models;
using Treetech.Alarms.WebApi.Repositories;
using Xunit;

namespace Treetech.Alarms.XUnit.Tests.Repositories
{
    public class AlarmeAtuadoRepositoryTest
    {
        private IAlarmeAtuadoRepository alarmeAtuadoRepository { get; set; }

        public AlarmeAtuadoRepositoryTest()
        {
            var builder = new DbContextOptionsBuilder<AlarmsContext>();
            builder.UseInMemoryDatabase("db_Alarms");

            AlarmsContext context = new AlarmsContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            alarmeAtuadoRepository = new AlarmeAtuadoRepository(context);
        }

        [Fact]
        public async void TestaCadastrarAlarmeAtuado()
        {
            var alarmeAtuado = new AlarmeAtuado()
            {
                IdAlarme = 1,
                DataEntrada = new DateTime(2021, 01, 20),
                DataSaida = new DateTime(2021, 02, 15)
            };

            var alarmeCadastrado = await alarmeAtuadoRepository.Cadastrar(alarmeAtuado);

            Assert.NotNull(alarmeCadastrado);
            Assert.False(alarmeCadastrado.Ativo);
            Assert.Equal(alarmeAtuado, alarmeCadastrado);
        }

        [Fact]
        public async void TestaListarAlarmesAtuados()
        {
            var list = await alarmeAtuadoRepository.Listar();

            Assert.NotNull(list);
            Assert.Empty(list);
        }


        [Fact]
        public async void TestaAlterStatusAlarmeAtuado()
        {
            var alarmeAtuado = new AlarmeAtuado()
            {
                IdAlarme = 1,
                DataEntrada = new DateTime(2021, 01, 20),
                DataSaida = new DateTime(2021, 02, 15)
            };

            var alarmeCadastrado = await alarmeAtuadoRepository.Cadastrar(alarmeAtuado);

            var alarmeAtivado = await alarmeAtuadoRepository.AlterarStatus(alarmeAtuado.IdAlarmeAtuado);

            Assert.NotNull(alarmeAtivado);
            Assert.True(alarmeAtivado.Ativo);
            Assert.Equal(alarmeAtuado, alarmeAtivado);
        }
    }
}
