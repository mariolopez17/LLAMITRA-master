using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LlamitraApi.Migrations
{
    /// <inheritdoc />
    public partial class NuevaClase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorialRefreshToken",
                columns: table => new
                {
                    IdHistorialToken = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: true),
                    Token = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    RefreshToken = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    ExpiratedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, computedColumnSql: "(case when [ExpiratedAt]<getdate() then CONVERT([bit],(0)) else CONVERT([bit],(1)) end)", stored: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Historia__03DC48A5BDFD22AD", x => x.IdHistorialToken);
                    table.ForeignKey(
                        name: "FK__Historial__IdUsu__24927208",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialRefreshToken_IdUser",
                table: "HistorialRefreshToken",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialRefreshToken");
        }
    }
}
