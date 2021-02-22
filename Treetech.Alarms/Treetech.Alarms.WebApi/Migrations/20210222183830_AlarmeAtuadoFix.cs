using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Treetech.Alarms.WebApi.Migrations
{
    public partial class AlarmeAtuadoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataSaida",
                table: "AlarmesAtuados",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataSaida",
                table: "AlarmesAtuados");
        }
    }
}
