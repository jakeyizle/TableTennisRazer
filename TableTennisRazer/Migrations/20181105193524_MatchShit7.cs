using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TableTennisRazer.Migrations
{
    public partial class MatchShit7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPerson_Person_PersonName",
                table: "MatchPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_MatchPerson_PersonName",
                table: "MatchPerson");

            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "MatchPerson");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPerson_Person_PersonId",
                table: "MatchPerson",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPerson_Person_PersonId",
                table: "MatchPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
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
                table: "MatchPerson",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "PersonName");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPerson_PersonName",
                table: "MatchPerson",
                column: "PersonName");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPerson_Person_PersonName",
                table: "MatchPerson",
                column: "PersonName",
                principalTable: "Person",
                principalColumn: "PersonName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
