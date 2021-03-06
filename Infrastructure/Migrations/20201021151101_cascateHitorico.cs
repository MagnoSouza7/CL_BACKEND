using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class cascateHitorico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historicos_Editais_EditalId",
                table: "Historicos");

            migrationBuilder.AddForeignKey(
                name: "FK_Historicos_Editais_EditalId",
                table: "Historicos",
                column: "EditalId",
                principalTable: "Editais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historicos_Editais_EditalId",
                table: "Historicos");

            migrationBuilder.AddForeignKey(
                name: "FK_Historicos_Editais_EditalId",
                table: "Historicos",
                column: "EditalId",
                principalTable: "Editais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
