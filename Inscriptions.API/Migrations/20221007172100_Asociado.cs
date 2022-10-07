using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inscriptions.API.Migrations
{
    public partial class Asociado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asociados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cedula = table.Column<string>(maxLength: 20, nullable: false),
                    NombreCompleto = table.Column<string>(maxLength: 100, nullable: false),
                    Empresa = table.Column<string>(maxLength: 100, nullable: false),
                    Departamento = table.Column<string>(maxLength: 100, nullable: false),
                    Municipio = table.Column<string>(maxLength: 100, nullable: false),
                    Zona = table.Column<string>(maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    HasInscription = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asociados", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asociados_Cedula",
                table: "Asociados",
                column: "Cedula",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asociados");
        }
    }
}
