using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoRiZa_Inventar.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benutzers",
                columns: table => new
                {
                    BenutzerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benutzers", x => x.BenutzerId);
                });

            migrationBuilder.CreateTable(
                name: "Kategories",
                columns: table => new
                {
                    KategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategorieName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategories", x => x.KategorieId);
                });

            migrationBuilder.CreateTable(
                name: "Raums",
                columns: table => new
                {
                    RaumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaumName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raums", x => x.RaumId);
                });

            migrationBuilder.CreateTable(
                name: "Gegs",
                columns: table => new
                {
                    GegenstandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GegenstandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategorieId = table.Column<int>(type: "int", nullable: false),
                    Beschreib = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anzahl = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gegs", x => x.GegenstandId);
                    table.ForeignKey(
                        name: "FK_Gegs_Kategories_KategorieId",
                        column: x => x.KategorieId,
                        principalTable: "Kategories",
                        principalColumn: "KategorieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenutzerId = table.Column<int>(type: "int", nullable: false),
                    GegenstandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.ComputerId);
                    table.ForeignKey(
                        name: "FK_Computers_Benutzers_BenutzerId",
                        column: x => x.BenutzerId,
                        principalTable: "Benutzers",
                        principalColumn: "BenutzerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_Gegs_GegenstandId",
                        column: x => x.GegenstandId,
                        principalTable: "Gegs",
                        principalColumn: "GegenstandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GegenstandId = table.Column<int>(type: "int", nullable: false),
                    Lagerbestand = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Materials_Gegs_GegenstandId",
                        column: x => x.GegenstandId,
                        principalTable: "Gegs",
                        principalColumn: "GegenstandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaumGegenstands",
                columns: table => new
                {
                    RaumGegenstandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RaumId = table.Column<int>(type: "int", nullable: false),
                    GegenstandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaumGegenstands", x => x.RaumGegenstandId);
                    table.ForeignKey(
                        name: "FK_RaumGegenstands_Gegs_GegenstandId",
                        column: x => x.GegenstandId,
                        principalTable: "Gegs",
                        principalColumn: "GegenstandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computers_BenutzerId",
                table: "Computers",
                column: "BenutzerId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_GegenstandId",
                table: "Computers",
                column: "GegenstandId");

            migrationBuilder.CreateIndex(
                name: "IX_Gegs_KategorieId",
                table: "Gegs",
                column: "KategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_GegenstandId",
                table: "Materials",
                column: "GegenstandId");

            migrationBuilder.CreateIndex(
                name: "IX_RaumGegenstands_GegenstandId",
                table: "RaumGegenstands",
                column: "GegenstandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "RaumGegenstands");

            migrationBuilder.DropTable(
                name: "Raums");

            migrationBuilder.DropTable(
                name: "Benutzers");

            migrationBuilder.DropTable(
                name: "Gegs");

            migrationBuilder.DropTable(
                name: "Kategories");
        }
    }
}
