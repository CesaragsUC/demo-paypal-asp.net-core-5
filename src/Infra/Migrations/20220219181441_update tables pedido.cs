using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class updatetablespedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Pedidos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "Pedidos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Pedidos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProdutoNome",
                table: "Pedidos",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "ProdutoNome",
                table: "Pedidos");
        }
    }
}
