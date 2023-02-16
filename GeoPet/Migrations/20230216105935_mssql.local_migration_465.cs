using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeoPet.Migrations
{
    public partial class mssqllocal_migration_465 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pets_CareGiverId",
                table: "Pets",
                column: "CareGiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_CareGivers_CareGiverId",
                table: "Pets",
                column: "CareGiverId",
                principalTable: "CareGivers",
                principalColumn: "CareGiverId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_CareGivers_CareGiverId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_CareGiverId",
                table: "Pets");
        }
    }
}
