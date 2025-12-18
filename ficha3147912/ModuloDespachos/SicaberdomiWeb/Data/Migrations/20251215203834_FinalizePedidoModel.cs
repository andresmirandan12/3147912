using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SicaberdomiWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class FinalizePedidoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ProductoPedido",
                table: "Pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "Observaciones",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Producto",
                table: "Pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Producto",
                table: "Pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "Observaciones",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "Latitud",
                table: "Pedidos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitud",
                table: "Pedidos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ProductoPedido",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
