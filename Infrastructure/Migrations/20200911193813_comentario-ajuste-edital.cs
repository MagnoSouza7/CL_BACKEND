using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class comentarioajusteedital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Editais_EditalId1",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_EditalId1",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "EditalId1",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "Menssagem",
                table: "Comentarios");

            migrationBuilder.AddColumn<string>(
                name: "Mensagem",
                table: "Comentarios",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mensagem",
                table: "Comentarios");

            migrationBuilder.AddColumn<int>(
                name: "EditalId1",
                table: "Comentarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Menssagem",
                table: "Comentarios",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_EditalId1",
                table: "Comentarios",
                column: "EditalId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Editais_EditalId1",
                table: "Comentarios",
                column: "EditalId1",
                principalTable: "Editais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
