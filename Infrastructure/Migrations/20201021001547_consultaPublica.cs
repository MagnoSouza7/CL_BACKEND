using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class consultaPublica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsultaPublicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataAtualizacao = table.Column<DateTime>(nullable: true),
                    NumConsulta = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: true),
                    EmpresaId = table.Column<int>(nullable: true),
                    DataResposta = table.Column<DateTime>(nullable: false),
                    AnexoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaPublicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultaPublicas_Anexos_AnexoId",
                        column: x => x.AnexoId,
                        principalTable: "Anexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ConsultaPublicas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsultaPublicas_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaPublicas_AnexoId",
                table: "ConsultaPublicas",
                column: "AnexoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaPublicas_ClienteId",
                table: "ConsultaPublicas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaPublicas_EmpresaId",
                table: "ConsultaPublicas",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultaPublicas");
        }
    }
}
