using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_doctors_specialtyys_specialtyId",
                table: "doctors");

            migrationBuilder.AlterColumn<int>(
                name: "specialtyId",
                table: "doctors",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "specialtyId",
                table: "doctors",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_specialtyys_specialtyId",
                table: "doctors",
                column: "specialtyId",
                principalTable: "specialtyys",
                principalColumn: "Id");
        }
    }
}
