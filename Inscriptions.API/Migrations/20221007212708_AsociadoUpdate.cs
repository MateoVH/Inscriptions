using Microsoft.EntityFrameworkCore.Migrations;

namespace Inscriptions.API.Migrations
{
    public partial class AsociadoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Asociados",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Asociados",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Asociados");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Asociados");
        }
    }
}
