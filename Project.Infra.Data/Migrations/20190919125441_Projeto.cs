using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Infra.Data.Migrations
{
    public partial class Projeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Encargos",
                columns: table => new
                {
                    IdEncargo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(maxLength: 150, nullable: false),
                    ContaDestino = table.Column<string>(maxLength: 150, nullable: false),
                    BancoDestino = table.Column<string>(maxLength: 150, nullable: false),
                    TipoConta = table.Column<string>(maxLength: 150, nullable: false),
                    CpfCnpjDestino = table.Column<string>(maxLength: 14, nullable: false),
                    ValorLancamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "date", nullable: false),
                    ValorEncargo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encargos", x => x.IdEncargo);
                });

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    IdLancamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(maxLength: 150, nullable: false),
                    ContaDestino = table.Column<string>(maxLength: 150, nullable: false),
                    BancoDestino = table.Column<string>(maxLength: 150, nullable: false),
                    TipoConta = table.Column<string>(maxLength: 150, nullable: false),
                    CpfCnpjDestino = table.Column<string>(maxLength: 14, nullable: false),
                    ValorLancamento = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataLancamento = table.Column<DateTime>(type: "date", nullable: false),
                    ValorEncargos = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.IdLancamento);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Encargos");

            migrationBuilder.DropTable(
                name: "Lancamentos");
        }
    }
}
