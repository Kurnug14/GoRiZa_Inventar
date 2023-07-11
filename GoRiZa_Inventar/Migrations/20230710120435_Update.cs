using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoRiZa_Inventar.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Benutzers_BenutzerId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Gegs_GegenstandId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gegs_Kategories_KategorieId",
                table: "Gegs");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Gegs_GegenstandId",
                table: "Materials");

            migrationBuilder.AlterColumn<int>(
                name: "GegenstandId",
                table: "Materials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KategorieId",
                table: "Gegs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GegenstandId",
                table: "Computers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BenutzerId",
                table: "Computers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Benutzers_BenutzerId",
                table: "Computers",
                column: "BenutzerId",
                principalTable: "Benutzers",
                principalColumn: "BenutzerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Gegs_GegenstandId",
                table: "Computers",
                column: "GegenstandId",
                principalTable: "Gegs",
                principalColumn: "GegenstandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gegs_Kategories_KategorieId",
                table: "Gegs",
                column: "KategorieId",
                principalTable: "Kategories",
                principalColumn: "KategorieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Gegs_GegenstandId",
                table: "Materials",
                column: "GegenstandId",
                principalTable: "Gegs",
                principalColumn: "GegenstandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Benutzers_BenutzerId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Gegs_GegenstandId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gegs_Kategories_KategorieId",
                table: "Gegs");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Gegs_GegenstandId",
                table: "Materials");

            migrationBuilder.AlterColumn<int>(
                name: "GegenstandId",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KategorieId",
                table: "Gegs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GegenstandId",
                table: "Computers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BenutzerId",
                table: "Computers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Benutzers_BenutzerId",
                table: "Computers",
                column: "BenutzerId",
                principalTable: "Benutzers",
                principalColumn: "BenutzerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Gegs_GegenstandId",
                table: "Computers",
                column: "GegenstandId",
                principalTable: "Gegs",
                principalColumn: "GegenstandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gegs_Kategories_KategorieId",
                table: "Gegs",
                column: "KategorieId",
                principalTable: "Kategories",
                principalColumn: "KategorieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Gegs_GegenstandId",
                table: "Materials",
                column: "GegenstandId",
                principalTable: "Gegs",
                principalColumn: "GegenstandId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
