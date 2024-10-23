using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LlamitraApi.Migrations
{
    /// <inheritdoc />
    public partial class PublicationStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PublicationRatings_IdPublication",
                table: "PublicationRatings",
                column: "IdPublication");

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationRatings_Publication_IdPublication",
                table: "PublicationRatings",
                column: "IdPublication",
                principalTable: "Publication",
                principalColumn: "idPublication",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PublicationRatings_Publication_IdPublication",
                table: "PublicationRatings");

            migrationBuilder.DropIndex(
                name: "IX_PublicationRatings_IdPublication",
                table: "PublicationRatings");
        }
    }
}
