using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class updatetablepedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProdutoId",
                table: "Pedidos",
                type: "varchar(500)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Pedidos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LinkOrder",
                table: "Pedidos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkSelfOrder",
                table: "Pedidos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderPaypalId",
                table: "Pedidos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayerEmail",
                table: "Pedidos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayerId",
                table: "Pedidos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayerName",
                table: "Pedidos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Pedidos",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "LinkOrder",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "LinkSelfOrder",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "OrderPaypalId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PayerEmail",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PayerId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "PayerName",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pedidos");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProdutoId",
                table: "Pedidos",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)");
        }
    }
}
