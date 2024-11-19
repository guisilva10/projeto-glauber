using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetopim.Migrations
{
    /// <inheritdoc />
    public partial class CreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Vendas",
                newName: "Produto");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Vendas",
                newName: "FormaDePagamento");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "CultivosEInsumos",
                newName: "Insumo");

            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Vendas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Vendas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Vendas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "Vendas",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Cultivo",
                table: "CultivosEInsumos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CultivoId",
                table: "CultivosEInsumos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Fornecedor",
                table: "CultivosEInsumos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FornecedorId",
                table: "CultivosEInsumos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InsumoId",
                table: "CultivosEInsumos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Vendas");

            migrationBuilder.DropColumn(
                name: "Cultivo",
                table: "CultivosEInsumos");

            migrationBuilder.DropColumn(
                name: "CultivoId",
                table: "CultivosEInsumos");

            migrationBuilder.DropColumn(
                name: "Fornecedor",
                table: "CultivosEInsumos");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "CultivosEInsumos");

            migrationBuilder.DropColumn(
                name: "InsumoId",
                table: "CultivosEInsumos");

            migrationBuilder.RenameColumn(
                name: "Produto",
                table: "Vendas",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "FormaDePagamento",
                table: "Vendas",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Insumo",
                table: "CultivosEInsumos",
                newName: "Name");
        }
    }
}
