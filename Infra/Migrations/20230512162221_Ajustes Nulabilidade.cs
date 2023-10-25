using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjustesNulabilidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Aula_AulaId",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "altura",
                table: "Usuario",
                newName: "Altura");

            migrationBuilder.AlterColumn<Guid>(
                name: "AulaId",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<bool>(
                name: "Administrador",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Aula_AulaId",
                table: "Usuario",
                column: "AulaId",
                principalTable: "Aula",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Aula_AulaId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Administrador",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Altura",
                table: "Usuario",
                newName: "altura");

            migrationBuilder.AlterColumn<Guid>(
                name: "AulaId",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Aula_AulaId",
                table: "Usuario",
                column: "AulaId",
                principalTable: "Aula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
