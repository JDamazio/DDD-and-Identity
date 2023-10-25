using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class Ajusteusuariodetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.CreateTable(
                name: "UsuarioDetail",
                columns: table => new
                {
                    AulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Pago = table.Column<bool>(type: "bit", nullable: false),
                    Plano = table.Column<int>(type: "int", nullable: false),
                    Administrador = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioDetail_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioDetail_Aula_AulaId",
                        column: x => x.AulaId,
                        principalTable: "Aula",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDetail_ApplicationUserId",
                table: "UsuarioDetail",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioDetail_AulaId",
                table: "UsuarioDetail",
                column: "AulaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioDetail");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    AulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Administrador = table.Column<bool>(type: "bit", nullable: false),
                    Altura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pago = table.Column<bool>(type: "bit", nullable: false),
                    Plano = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Aula_AulaId",
                        column: x => x.AulaId,
                        principalTable: "Aula",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_AulaId",
                table: "Usuario",
                column: "AulaId");
        }
    }
}
