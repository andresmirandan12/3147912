using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SicaberdomiWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class ComentarioCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios");

            migrationBuilder.RenameTable(
                name: "Comentarios",
                newName: "ComentariosCliente");

            migrationBuilder.AlterColumn<string>(
                name: "Observaciones",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "ComentariosCliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComentariosCliente",
                table: "ComentariosCliente",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosCliente_PedidoId",
                table: "ComentariosCliente",
                column: "PedidoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComentariosCliente_Pedidos_PedidoId",
                table: "ComentariosCliente",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComentariosCliente_Pedidos_PedidoId",
                table: "ComentariosCliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComentariosCliente",
                table: "ComentariosCliente");

            migrationBuilder.DropIndex(
                name: "IX_ComentariosCliente_PedidoId",
                table: "ComentariosCliente");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "ComentariosCliente");

            migrationBuilder.RenameTable(
                name: "ComentariosCliente",
                newName: "Comentarios");

            migrationBuilder.AlterColumn<string>(
                name: "Observaciones",
                table: "Pedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios",
                column: "Id");
        }
    }
}
