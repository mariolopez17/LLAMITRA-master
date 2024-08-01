using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LlamitraApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
