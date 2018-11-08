using Microsoft.EntityFrameworkCore.Migrations;

namespace TableTennisRazer.Migrations
{
    public partial class MatchShit6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Match_MatchId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_MatchId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "LosingPersonTwo",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "WinningPersonTwo",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "LosingPersonOne",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "WinningPersonOne",
                table: "Match");

            migrationBuilder.AlterColumn<int>(
                name: "WinningScore",
                table: "Match",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "LosingScore",
                table: "Match",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "MatchPerson",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    MatchResult = table.Column<int>(nullable: false),
                    PersonName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPerson", x => new { x.PersonId, x.MatchId });
                    table.ForeignKey(
                        name: "FK_MatchPerson_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchPerson_Person_PersonName",
                        column: x => x.PersonName,
                        principalTable: "Person",
                        principalColumn: "PersonName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchPerson_MatchId",
                table: "MatchPerson",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPerson_PersonName",
                table: "MatchPerson",
                column: "PersonName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchPerson");

            migrationBuilder.AddColumn<int>(
                name: "MatchId",
                table: "Person",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WinningScore",
                table: "Match",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LosingScore",
                table: "Match",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LosingPersonTwo",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WinningPersonTwo",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Match",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LosingPersonOne",
                table: "Match",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WinningPersonOne",
                table: "Match",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_MatchId",
                table: "Person",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Match_MatchId",
                table: "Person",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
