using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LlamitraApi.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPublicationProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "category",
                table: "Publication",
                type: "varchar(max)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "comprado",
                table: "Publication",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "descriptionProgram",
                table: "Publication",
                type: "varchar(max)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "duration",
                table: "Publication",
                type: "varchar(max)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "durationWeek",
                table: "Publication",
                type: "varchar(max)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "favorite",
                table: "Publication",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "knowledgeLevel",
                table: "Publication",
                type: "varchar(max)",
                unicode: false,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "comprado",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "descriptionProgram",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "duration",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "durationWeek",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "favorite",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "knowledgeLevel",
                table: "Publication");
        }
    }
}
