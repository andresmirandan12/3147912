using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SicaberdomiWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModelosInicialesYRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstaDisponible",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NombreCompleto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false),
                    TextoComentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaComentario = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductoPedido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionEntrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false),
                    FechaPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DomiciliarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_AspNetUsers_DomiciliarioId",
                        column: x => x.DomiciliarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_DomiciliarioId",
                table: "Pedidos",
                column: "DomiciliarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropColumn(
                name: "EstaDisponible",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NombreCompleto",
                table: "AspNetUsers");
        }
    }
}
