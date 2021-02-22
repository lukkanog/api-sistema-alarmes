using Microsoft.EntityFrameworkCore.Migrations;

namespace Treetech.Alarms.WebApi.Migrations
{
    public partial class MakeSerialNumberUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_NumeroSerie",
                table: "Equipamentos",
                column: "NumeroSerie",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Equipamentos_NumeroSerie",
                table: "Equipamentos");
        }
    }
}
