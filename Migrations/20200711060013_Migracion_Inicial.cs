using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudiantePrestamoReportes.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Matricula = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    CalifPromedio = table.Column<float>(nullable: false),
                    CalifMax = table.Column<float>(nullable: false),
                    CalifMin = table.Column<float>(nullable: false),
                    TotalPts = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Matricula);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    IdPrestamo = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdPersona = table.Column<int>(nullable: false),
                    Monto = table.Column<double>(nullable: false),
                    ConceptoPrestamo = table.Column<string>(nullable: true),
                    FechaPrestamo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.IdPrestamo);
                });

            migrationBuilder.CreateTable(
                name: "EstudianteDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Calificacion = table.Column<float>(nullable: false),
                    Valor = table.Column<float>(nullable: false),
                    TipoEvaluacion = table.Column<string>(nullable: true),
                    FechaEvaluacion = table.Column<DateTime>(nullable: false),
                    Observacion = table.Column<string>(nullable: true),
                    Matricula = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudianteDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstudianteDetalle_Estudiantes_Matricula",
                        column: x => x.Matricula,
                        principalTable: "Estudiantes",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstudianteDetalle_Matricula",
                table: "EstudianteDetalle",
                column: "Matricula");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudianteDetalle");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Estudiantes");
        }
    }
}
