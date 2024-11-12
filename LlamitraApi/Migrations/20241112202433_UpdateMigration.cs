using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LlamitraApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "Video");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Video",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Video");

            migrationBuilder.AddColumn<byte[]>(
                name: "FileContent",
                table: "Video",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
