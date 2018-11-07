using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TableTennisRazer.Migrations
{
    public partial class RemovedPersonId12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPeople_Person_PersonId",
                table: "MatchPeople");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_PersonName",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Person");

            migrationBuilder.AlterColumn<string>(
                name: "PersonName",
                table: "Person",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonName",
                table: "MatchPeople",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "PersonName");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonName",
                table: "Person",
                column: "PersonName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchPeople_PersonName",
                table: "MatchPeople",
                column: "PersonName");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPeople_Person_PersonName",
                table: "MatchPeople",
                column: "PersonName",
                principalTable: "Person",
                principalColumn: "PersonName",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPeople_Person_PersonName",
                table: "MatchPeople");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_PersonName",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_MatchPeople_PersonName",
                table: "MatchPeople");

            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "MatchPeople");

            migrationBuilder.AlterColumn<string>(
                name: "PersonName",
                table: "Person",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Person",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonName",
                table: "Person",
                column: "PersonName",
                unique: true,
                filter: "[PersonName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPeople_Person_PersonId",
                table: "MatchPeople",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
