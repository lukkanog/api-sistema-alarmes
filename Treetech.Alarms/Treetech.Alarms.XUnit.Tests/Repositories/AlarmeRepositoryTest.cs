using Microsoft.EntityFrameworkCore;
using Xunit;
using Treetech.Alarms.WebApi.Contexts;
using Treetech.Alarms.WebApi.Interfaces;
using Treetech.Alarms.WebApi.Repositories;
using Treetech.Alarms.WebApi.Models;
using System.Threading.Tasks;

namespace Treetech.Alarms.XUnit.Tests.Repositories
{
    public class AlarmeRepositoryTest
    {
        private IAlarmeRepository alarmeRepository { get; set; }
        public AlarmeRepositoryTest()
        {
            var builder = new DbContextOptionsBuilder<AlarmsContext>();
            builder.UseInMemoryDatabase("db_Alarms");

            AlarmsContext context = new AlarmsContext(builder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            alarmeRepository = new AlarmeRepository(context);
        }


        [Fact]
        public async void TestaCadastrarAlarme()
        {
            var alarme = new Alarme()
            {
                Descricao = "Alarme teste xunit",
                IdClassificacao = 1,
                IdAlarme = 1,
            };

            var alarmeCadastrado = await alarmeRepository.Cadastrar(alarme);

            Assert.NotNull(alarmeCadastrado);
            Assert.Equal(alarme, alarmeCadastrado);
            
        }

        [Fact]
        public async void TestaListarAlarmes()
        {
            var list = await alarmeRepository.Listar();

            Assert.NotNull(list);
            Assert.Empty(list);
        }

        [Fact]
        public async void TestaEditarAlarme()
        {
            var alarme = new Alarme()
            {
                Descricao = "Alarme teste update",
                IdClassificacao = 1,
                IdAlarme = 1,
            };

            var alarmeCadastrado = await alarmeRepository.Cadastrar(alarme);

            alarmeCadastrado.Descricao = "descrição alterada";
            alarmeCadastrado.IdClassificacao = 2;

            var alarmeEditado = await alarmeRepository.Editar(alarmeCadastrado);

            Assert.NotNull(alarmeEditado);
            Assert.Equal("descrição alterada", alarmeEditado.Descricao);
            Assert.Equal(2, alarmeEditado.IdClassificacao);
        }

        [Fact]
        public async void TestaExcluirAlarme()
        {
            var alarme = new Alarme()
            {
                Descricao = "Alarme teste xunit",
                IdClassificacao = 1,
                IdAlarme = 1,
            };

            var alarmeCadastrado = await alarmeRepository.Cadastrar(alarme);

            var alarmeExcluido = await alarmeRepository.Excluir(alarmeCadastrado.IdAlarme);

            Assert.NotNull(alarmeExcluido);
            Assert.Equal(alarmeCadastrado, alarmeExcluido);
        }



    }
}
