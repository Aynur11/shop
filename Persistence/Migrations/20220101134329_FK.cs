using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirstLevelImageSection_FirstLevelIconSection_FirstLevelIconSectionId",
                table: "FirstLevelImageSection");

            migrationBuilder.DropForeignKey(
                name: "FK_FirstLevelImageSection_SecondLevelSection_SecondLevelSectionId",
                table: "FirstLevelImageSection");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_FirstLevelIconSection_FirstLevelIconSectionId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_FirstLevelImageSection_FirstLevelImageSectionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FirstLevelIconSectionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_FirstLevelImageSectionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_FirstLevelImageSection_SecondLevelSectionId",
                table: "FirstLevelImageSection");

            migrationBuilder.DropColumn(
                name: "FirstLevelIconSectionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FirstLevelImageSectionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SecondLevelSectionId",
                table: "FirstLevelImageSection");

            migrationBuilder.AddColumn<int>(
                name: "FirstLevelImageSectionId",
                table: "SecondLevelSection",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FirstLevelIconSectionId",
                table: "FirstLevelImageSection",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecondLevelSection_FirstLevelImageSectionId",
                table: "SecondLevelSection",
                column: "FirstLevelImageSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FirstLevelImageSection_FirstLevelIconSection_FirstLevelIconSectionId",
                table: "FirstLevelImageSection",
                column: "FirstLevelIconSectionId",
                principalTable: "FirstLevelIconSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecondLevelSection_FirstLevelImageSection_FirstLevelImageSectionId",
                table: "SecondLevelSection",
                column: "FirstLevelImageSectionId",
                principalTable: "FirstLevelImageSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirstLevelImageSection_FirstLevelIconSection_FirstLevelIconSectionId",
                table: "FirstLevelImageSection");

            migrationBuilder.DropForeignKey(
                name: "FK_SecondLevelSection_FirstLevelImageSection_FirstLevelImageSectionId",
                table: "SecondLevelSection");

            migrationBuilder.DropIndex(
                name: "IX_SecondLevelSection_FirstLevelImageSectionId",
                table: "SecondLevelSection");

            migrationBuilder.DropColumn(
                name: "FirstLevelImageSectionId",
                table: "SecondLevelSection");

            migrationBuilder.AddColumn<int>(
                name: "FirstLevelIconSectionId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstLevelImageSectionId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FirstLevelIconSectionId",
                table: "FirstLevelImageSection",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SecondLevelSectionId",
                table: "FirstLevelImageSection",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_FirstLevelIconSectionId",
                table: "Products",
                column: "FirstLevelIconSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FirstLevelImageSectionId",
                table: "Products",
                column: "FirstLevelImageSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstLevelImageSection_SecondLevelSectionId",
                table: "FirstLevelImageSection",
                column: "SecondLevelSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FirstLevelImageSection_FirstLevelIconSection_FirstLevelIconSectionId",
                table: "FirstLevelImageSection",
                column: "FirstLevelIconSectionId",
                principalTable: "FirstLevelIconSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FirstLevelImageSection_SecondLevelSection_SecondLevelSectionId",
                table: "FirstLevelImageSection",
                column: "SecondLevelSectionId",
                principalTable: "SecondLevelSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FirstLevelIconSection_FirstLevelIconSectionId",
                table: "Products",
                column: "FirstLevelIconSectionId",
                principalTable: "FirstLevelIconSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FirstLevelImageSection_FirstLevelImageSectionId",
                table: "Products",
                column: "FirstLevelImageSectionId",
                principalTable: "FirstLevelImageSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
