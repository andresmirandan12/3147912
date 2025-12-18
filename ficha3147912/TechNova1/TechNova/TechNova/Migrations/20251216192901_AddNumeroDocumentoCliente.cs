using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechNova.Migrations
{
    public partial class AddNumeroDocumentoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1️⃣ Agregar columna permitiendo NULL
            migrationBuilder.AddColumn<string>(
                name: "NumeroDocumento",
                table: "Clientes",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: true);

            // 2️⃣ Asignar valores únicos temporales
            migrationBuilder.Sql(@"
                UPDATE Clientes
                SET NumeroDocumento = CONCAT('TEMP-', ClienteID)
                WHERE NumeroDocumento IS NULL
            ");

            // 3️⃣ Cambiar a NOT NULL
            migrationBuilder.AlterColumn<string>(
                name: "NumeroDocumento",
                table: "Clientes",
                type: "varchar(20)",
                unicode: false,
                maxLength: 20,
                nullable: false);

            // 4️⃣ Índice único
            migrationBuilder.CreateIndex(
                name: "IX_Clientes_NumeroDocumento",
                table: "Clientes",
                column: "NumeroDocumento",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_NumeroDocumento",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "NumeroDocumento",
                table: "Clientes");
        }
    }
}

