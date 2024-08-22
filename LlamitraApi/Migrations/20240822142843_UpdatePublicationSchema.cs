using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LlamitraApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePublicationSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publication_PublicationTypes_IdTypeNavigationIdType",
                table: "Publication");

            migrationBuilder.DropIndex(
                name: "IX_Publication_IdTypeNavigationIdType",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "IdTypeNavigationIdType",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "url",
                table: "Publication");

            migrationBuilder.AddColumn<byte[]>(
                name: "FileContent",
                table: "Publication",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Publication",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publication_idType",
                table: "Publication",
                column: "idType");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_IdType",
                table: "Publication",
                column: "idType",
                principalTable: "PublicationTypes",
                principalColumn: "idPublicationType",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_IdType",
                table: "Publication");

            migrationBuilder.DropIndex(
                name: "IX_Publication_idType",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Publication");

            migrationBuilder.AddColumn<int>(
                name: "IdTypeNavigationIdType",
                table: "Publication",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "Publication",
                type: "varchar(450)",
                unicode: false,
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publication_IdTypeNavigationIdType",
                table: "Publication",
                column: "IdTypeNavigationIdType");

            migrationBuilder.AddForeignKey(
                name: "FK_Publication_PublicationTypes_IdTypeNavigationIdType",
                table: "Publication",
                column: "IdTypeNavigationIdType",
                principalTable: "PublicationTypes",
                principalColumn: "idPublicationType");
        }
    }
}
