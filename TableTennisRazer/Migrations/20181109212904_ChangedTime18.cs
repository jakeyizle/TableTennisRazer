using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TableTennisRazer.Migrations
{
    public partial class ChangedTime18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "MatchPeople");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Match",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Match");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "MatchPeople",
                nullable: false,
                defaultValueSql: "getdate()");
        }
    }
}
