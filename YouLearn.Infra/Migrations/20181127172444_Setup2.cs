using Microsoft.EntityFrameworkCore.Migrations;

namespace YouLearn.Infra.Migrations
{
    public partial class Setup2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UltinoNome",
                table: "Usuario",
                newName: "UltimoNome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UltimoNome",
                table: "Usuario",
                newName: "UltinoNome");
        }
    }
}
