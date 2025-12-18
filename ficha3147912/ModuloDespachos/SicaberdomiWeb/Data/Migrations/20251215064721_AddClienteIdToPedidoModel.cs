using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SicaberdomiWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddClienteIdToPedidoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_AspNetUsers_DomiciliarioId",
                table: "Pedidos");

            migrationBuilder.AlterColumn<string>(
                name: "Observaciones",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DomiciliarioId",
                table: "Pedidos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ClienteId",
                table: "Pedidos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_AspNetUsers_ClienteId",
                table: "Pedidos",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_AspNetUsers_DomiciliarioId",
                table: "Pedidos",
                column: "DomiciliarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_AspNetUsers_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_AspNetUsers_DomiciliarioId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_ClienteId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
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

            migrationBuilder.AlterColumn<string>(
                name: "DomiciliarioId",
                table: "Pedidos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_AspNetUsers_DomiciliarioId",
                table: "Pedidos",
                column: "DomiciliarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
