using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LlamitraApi.Migrations
{
    /// <inheritdoc />
    public partial class PublicationStartUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublicationRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPublication = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdPublicationNavigationIdPublication = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicationRatings_Publication_IdPublication",
                        column: x => x.IdPublication,
                        principalTable: "Publication",
                        principalColumn: "idPublication",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicationRatings_Publication_IdPublicationNavigationIdPublication",
                        column: x => x.IdPublicationNavigationIdPublication,
                        principalTable: "Publication",
                        principalColumn: "idPublication");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicationRatings_IdPublication",
                table: "PublicationRatings",
                column: "IdPublication");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationRatings_IdPublicationNavigationIdPublication",
                table: "PublicationRatings",
                column: "IdPublicationNavigationIdPublication");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicationRatings");
        }
    }
}
