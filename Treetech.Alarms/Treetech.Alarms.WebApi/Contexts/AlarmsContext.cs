using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Treetech.Alarms.WebApi.Models;

namespace Treetech.Alarms.WebApi.Contexts
{
    public class AlarmsContext : DbContext
    {
        public AlarmsContext() {}

        public AlarmsContext(DbContextOptions<AlarmsContext> options) : base(options) {}

        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Alarme> Alarmes { get; set; }
        public DbSet<AlarmeAtuado> AlarmesAtuados { get; set; }
        public DbSet<TipoEquipamento> TiposEquipamento { get; set; }
        public DbSet<ClassificacaoAlarme> ClassificacoesAlarme { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=db_Alarms;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Insere os tipos de equipamento predefinidos no banco de dados.
            builder.Entity<TipoEquipamento>(entity =>
            {
                entity.HasData(
                    new TipoEquipamento { IdTipo = 1, NomeTipo = "Tensão"},
                    new TipoEquipamento { IdTipo = 2, NomeTipo = "Corrente" },
                    new TipoEquipamento { IdTipo = 3, NomeTipo = "Óleo" }
                    );
            });

            //Insere as clasificações de alarme predefinidas no banco de dados.
            builder.Entity<ClassificacaoAlarme>(entity =>
            {
                entity.HasData(
                    new ClassificacaoAlarme { IdClassificacao = 1, NomeClassificacao = "Baixo" },
                    new ClassificacaoAlarme { IdClassificacao = 2, NomeClassificacao = "Médio" },
                    new ClassificacaoAlarme { IdClassificacao = 3, NomeClassificacao = "Alto" }
                    );
            });

            builder.Entity<Equipamento>(entity =>
            {
                entity.HasIndex(e => e.NumeroSerie).IsUnique();
            });
        }

    }
}
