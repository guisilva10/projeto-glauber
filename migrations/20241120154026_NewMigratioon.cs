using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetopim.Migrations
{
    /// <inheritdoc />
    public partial class NewMigratioon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormaDePagamentoId",
                table: "Vendas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FormaDePagamentoId",
                table: "Vendas",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
