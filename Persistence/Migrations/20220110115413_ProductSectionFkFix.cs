using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ProductSectionFkFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SecondLevelSections_SecondLevelSectionId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "SecondLevelSectionId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SecondLevelSections_SecondLevelSectionId",
                table: "Products",
                column: "SecondLevelSectionId",
                principalTable: "SecondLevelSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_SecondLevelSections_SecondLevelSectionId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "SecondLevelSectionId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SecondLevelSections_SecondLevelSectionId",
                table: "Products",
                column: "SecondLevelSectionId",
                principalTable: "SecondLevelSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
