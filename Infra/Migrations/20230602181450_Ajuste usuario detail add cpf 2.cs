﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Ajusteusuariodetailaddcpf2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioDetail_AspNetUsers_ApplicationUserId",
                table: "UsuarioDetail");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UsuarioDetail",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioDetail_AspNetUsers_ApplicationUserId",
                table: "UsuarioDetail",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioDetail_AspNetUsers_ApplicationUserId",
                table: "UsuarioDetail");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UsuarioDetail",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioDetail_AspNetUsers_ApplicationUserId",
                table: "UsuarioDetail",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
