using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Treetech.Alarms.WebApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassificacoesAlarme",
                columns: table => new
                {
                    IdClassificacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeClassificacao = table.Column<string>(type: "VARCHAR(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificacoesAlarme", x => x.IdClassificacao);
                });

            migrationBuilder.CreateTable(
                name: "TiposEquipamento",
                columns: table => new
                {
                    IdTipo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTipo = table.Column<string>(type: "VARCHAR(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposEquipamento", x => x.IdTipo);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    IdEquipamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEquipamento = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    NumeroSerie = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    IdTipo = table.Column<int>(nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.IdEquipamento);
                    table.ForeignKey(
                        name: "FK_Equipamentos_TiposEquipamento_IdTipo",
                        column: x => x.IdTipo,
                        principalTable: "TiposEquipamento",
                        principalColumn: "IdTipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alarmes",
                columns: table => new
                {
                    IdAlarme = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "VARCHAR(250)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdClassificacao = table.Column<int>(nullable: false),
                    IdEquipamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarmes", x => x.IdAlarme);
                    table.ForeignKey(
                        name: "FK_Alarmes_ClassificacoesAlarme_IdClassificacao",
                        column: x => x.IdClassificacao,
                        principalTable: "ClassificacoesAlarme",
                        principalColumn: "IdClassificacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alarmes_Equipamentos_IdEquipamento",
                        column: x => x.IdEquipamento,
                        principalTable: "Equipamentos",
                        principalColumn: "IdEquipamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlarmesAtuados",
                columns: table => new
                {
                    IdAlarmeAtuado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAlarme = table.Column<int>(nullable: false),
                    DataEntrada = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Ativo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmesAtuados", x => x.IdAlarmeAtuado);
                    table.ForeignKey(
                        name: "FK_AlarmesAtuados_Alarmes_IdAlarme",
                        column: x => x.IdAlarme,
                        principalTable: "Alarmes",
                        principalColumn: "IdAlarme",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClassificacoesAlarme",
                columns: new[] { "IdClassificacao", "NomeClassificacao" },
                values: new object[,]
                {
                    { 1, "Baixo" },
                    { 2, "Médio" },
                    { 3, "Alto" }
                });

            migrationBuilder.InsertData(
                table: "TiposEquipamento",
                columns: new[] { "IdTipo", "NomeTipo" },
                values: new object[,]
                {
                    { 1, "Tensão" },
                    { 2, "Corrente" },
                    { 3, "Óleo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alarmes_IdClassificacao",
                table: "Alarmes",
                column: "IdClassificacao");

            migrationBuilder.CreateIndex(
                name: "IX_Alarmes_IdEquipamento",
                table: "Alarmes",
                column: "IdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_AlarmesAtuados_IdAlarme",
                table: "AlarmesAtuados",
                column: "IdAlarme");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_IdTipo",
                table: "Equipamentos",
                column: "IdTipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlarmesAtuados");

            migrationBuilder.DropTable(
                name: "Alarmes");

            migrationBuilder.DropTable(
                name: "ClassificacoesAlarme");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "TiposEquipamento");
        }
    }
}
