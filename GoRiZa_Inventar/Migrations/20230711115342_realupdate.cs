using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoRiZa_Inventar.Migrations
{
    /// <inheritdoc />
    public partial class realupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RaumGegenstands_RaumId",
                table: "RaumGegenstands",
                column: "RaumId");

            migrationBuilder.AddForeignKey(
                name: "FK_RaumGegenstands_Raums_RaumId",
                table: "RaumGegenstands",
                column: "RaumId",
                principalTable: "Raums",
                principalColumn: "RaumId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaumGegenstands_Raums_RaumId",
                table: "RaumGegenstands");

            migrationBuilder.DropIndex(
                name: "IX_RaumGegenstands_RaumId",
                table: "RaumGegenstands");
        }
    }
}
