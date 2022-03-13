using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "specialty",
                table: "doctors",
                newName: "specialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_doctors_specialtyId",
                table: "doctors",
                column: "specialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_specialtyys_specialtyId",
                table: "doctors",
                column: "specialtyId",
                principalTable: "specialtyys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctors_specialtyys_specialtyId",
                table: "doctors");

            migrationBuilder.DropIndex(
                name: "IX_doctors_specialtyId",
                table: "doctors");

            migrationBuilder.RenameColumn(
                name: "specialtyId",
                table: "doctors",
                newName: "specialty");
        }
    }
}
