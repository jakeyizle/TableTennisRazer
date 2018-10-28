using Microsoft.EntityFrameworkCore.Migrations;

namespace TableTennisRazer.Migrations
{
    public partial class MatchSepFix5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LosingPersonTwo",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WinningPersonTwo",
                table: "Match",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LosingPersonTwo",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "WinningPersonTwo",
                table: "Match");
        }
    }
}
