using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LlamitraApi.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublicationTypes",
                columns: table => new
                {
                    idPublicationType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idPublicationType", x => x.idPublicationType);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    idRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idRol", x => x.idRol);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    lastname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    mail = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    idRol = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idUser", x => x.idUser);
                    table.ForeignKey(
                        name: "FK__Users__idRol__3B75D760",
                        column: x => x.idRol,
                        principalTable: "Roles",
                        principalColumn: "idRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publication",
                columns: table => new
                {
                    idPublication = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdType = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    professor = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: true),
                    url = table.Column<string>(type: "varchar(450)", unicode: false, maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_idPublication", x => x.idPublication);
                    table.ForeignKey(
                        name: "FK__Publications__idRol",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Publications__idType",
                        column: x => x.IdType,
                        principalTable: "PublicationTypes",
                        principalColumn: "idPublicationType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publication_IdType",
                table: "Publication",
                column: "IdType");

            migrationBuilder.CreateIndex(
                name: "IX_Publication_IdUser",
                table: "Publication",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_idRol",
                table: "Users",
                column: "idRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publication");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PublicationTypes");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
