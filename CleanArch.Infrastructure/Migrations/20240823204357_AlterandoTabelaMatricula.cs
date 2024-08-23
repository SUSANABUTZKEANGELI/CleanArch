using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoTabelaMatricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Matricula",
                table: "Matricula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matricula",
                table: "Matricula",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_IdCurso",
                table: "Matricula",
                column: "IdCurso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Matricula",
                table: "Matricula");

            migrationBuilder.DropIndex(
                name: "IX_Matricula_IdCurso",
                table: "Matricula");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matricula",
                table: "Matricula",
                columns: new[] { "IdCurso", "IdAluno" });
        }
    }
}
