using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TableTennisRazer.Migrations
{
    public partial class MatchSeparation4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchPerson");

            migrationBuilder.AddColumn<int>(
                name: "MatchID",
                table: "Person",
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
                name: "IX_Person_MatchID",
                table: "Person",
                column: "MatchID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Match_MatchID",
                table: "Person",
                column: "MatchID",
                principalTable: "Match",
                principalColumn: "MatchID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Match_MatchID",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_MatchID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MatchID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "LosingPersonOne",
                table: "Match");

            migrationBuilder.DropColumn(
                name: "WinningPersonOne",
                table: "Match");

            migrationBuilder.CreateTable(
                name: "MatchPerson",
                columns: table => new
                {
                    MatchPersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(nullable: false),
                    PersonName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPerson", x => x.MatchPersonId);
                    table.ForeignKey(
                        name: "FK_MatchPerson_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "MatchID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchPerson_Person_PersonName",
                        column: x => x.PersonName,
                        principalTable: "Person",
                        principalColumn: "PersonName",
                        onDelete: ReferentialAction.Restrict);
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
    }
}
