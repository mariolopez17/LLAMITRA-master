using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LlamitraApi.Migrations
{
    /// <inheritdoc />
    public partial class ArregloFKPublication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Publications__idRol",
                table: "Publication");

            migrationBuilder.RenameColumn(
                name: "idUser",
                table: "Publication",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "idType",
                table: "Publication",
                newName: "IdType");

            migrationBuilder.RenameIndex(
                name: "IX_Publication_idUser",
                table: "Publication",
                newName: "IX_Publication_IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Publication_idType",
                table: "Publication",
                newName: "IX_Publication_IdType");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_IdUser",
                table: "Publication",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "idUser",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_IdUser",
                table: "Publication");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Publication",
                newName: "idUser");

            migrationBuilder.RenameColumn(
                name: "IdType",
                table: "Publication",
                newName: "idType");

            migrationBuilder.RenameIndex(
                name: "IX_Publication_IdUser",
                table: "Publication",
                newName: "IX_Publication_idUser");

            migrationBuilder.RenameIndex(
                name: "IX_Publication_IdType",
                table: "Publication",
                newName: "IX_Publication_idType");

            migrationBuilder.AddForeignKey(
                name: "FK__Publications__idRol",
                table: "Publication",
                column: "idUser",
                principalTable: "Users",
                principalColumn: "idUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
