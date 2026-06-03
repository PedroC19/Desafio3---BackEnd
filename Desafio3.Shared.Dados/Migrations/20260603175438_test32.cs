using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio3.Shared.Dados.Migrations
{
    /// <inheritdoc />
    public partial class test32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivos");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extra = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    Extra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
