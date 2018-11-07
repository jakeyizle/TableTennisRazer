using Microsoft.EntityFrameworkCore.Migrations;

namespace TableTennisRazer.Migrations
{
    public partial class Doodle8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPerson_Match_MatchId",
                table: "MatchPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchPerson_Person_PersonId",
                table: "MatchPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchPerson",
                table: "MatchPerson");

            migrationBuilder.RenameTable(
                name: "MatchPerson",
                newName: "MatchPeople");

            migrationBuilder.RenameIndex(
                name: "IX_MatchPerson_MatchId",
                table: "MatchPeople",
                newName: "IX_MatchPeople_MatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchPeople",
                table: "MatchPeople",
                columns: new[] { "PersonId", "MatchId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPeople_Match_MatchId",
                table: "MatchPeople",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPeople_Person_PersonId",
                table: "MatchPeople",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPeople_Match_MatchId",
                table: "MatchPeople");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchPeople_Person_PersonId",
                table: "MatchPeople");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MatchPeople",
                table: "MatchPeople");

            migrationBuilder.RenameTable(
                name: "MatchPeople",
                newName: "MatchPerson");

            migrationBuilder.RenameIndex(
                name: "IX_MatchPeople_MatchId",
                table: "MatchPerson",
                newName: "IX_MatchPerson_MatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MatchPerson",
                table: "MatchPerson",
                columns: new[] { "PersonId", "MatchId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPerson_Match_MatchId",
                table: "MatchPerson",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPerson_Person_PersonId",
                table: "MatchPerson",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
