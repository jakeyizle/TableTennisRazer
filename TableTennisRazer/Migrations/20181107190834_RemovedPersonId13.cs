using Microsoft.EntityFrameworkCore.Migrations;

namespace TableTennisRazer.Migrations
{
    public partial class RemovedPersonId13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchPeople",
                table: "MatchPeople");

            migrationBuilder.DropIndex(
                name: "IX_MatchPeople_PersonName",
                table: "MatchPeople");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "MatchPeople");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchPeople",
                table: "MatchPeople",
                columns: new[] { "PersonName", "MatchId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchPeople",
                table: "MatchPeople");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "MatchPeople",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchPeople",
                table: "MatchPeople",
                columns: new[] { "PersonId", "MatchId" });

            migrationBuilder.CreateIndex(
                name: "IX_MatchPeople_PersonName",
                table: "MatchPeople",
                column: "PersonName");
        }
    }
}
