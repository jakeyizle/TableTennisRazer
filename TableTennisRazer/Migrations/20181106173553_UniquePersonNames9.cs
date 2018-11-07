using Microsoft.EntityFrameworkCore.Migrations;

namespace TableTennisRazer.Migrations
{
    public partial class UniquePersonNames9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PersonName",
                table: "Person",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonName",
                table: "Person",
                column: "PersonName",
                unique: true,
                filter: "[PersonName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Person_PersonName",
                table: "Person");

            migrationBuilder.AlterColumn<string>(
                name: "PersonName",
                table: "Person",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
