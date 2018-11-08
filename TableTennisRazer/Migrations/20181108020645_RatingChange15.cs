using Microsoft.EntityFrameworkCore.Migrations;

namespace TableTennisRazer.Migrations
{
    public partial class RatingChange15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Match",
                newName: "MatchId");

            migrationBuilder.AddColumn<double>(
                name: "RatingChange",
                table: "MatchPeople",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingChange",
                table: "MatchPeople");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Match",
                newName: "MatchId");
        }
    }
}
