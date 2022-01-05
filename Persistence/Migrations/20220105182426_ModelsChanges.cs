using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ModelsChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirstLevelImageSection_FirstLevelIconSections_FirstLevelIconSectionId",
                table: "FirstLevelImageSection");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SecondLevelSection_SecondLevelSectionId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SecondLevelSection_FirstLevelImageSection_FirstLevelImageSectionId",
                table: "SecondLevelSection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecondLevelSection",
                table: "SecondLevelSection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FirstLevelImageSection",
                table: "FirstLevelImageSection");

            migrationBuilder.RenameTable(
                name: "SecondLevelSection",
                newName: "SecondLevelSections");

            migrationBuilder.RenameTable(
                name: "FirstLevelImageSection",
                newName: "FirstLevelImageSections");

            migrationBuilder.RenameIndex(
                name: "IX_SecondLevelSection_FirstLevelImageSectionId",
                table: "SecondLevelSections",
                newName: "IX_SecondLevelSections_FirstLevelImageSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_FirstLevelImageSection_FirstLevelIconSectionId",
                table: "FirstLevelImageSections",
                newName: "IX_FirstLevelImageSections_FirstLevelIconSectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecondLevelSections",
                table: "SecondLevelSections",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FirstLevelImageSections",
                table: "FirstLevelImageSections",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FirstLevelImageSections_FirstLevelIconSections_FirstLevelIconSectionId",
                table: "FirstLevelImageSections",
                column: "FirstLevelIconSectionId",
                principalTable: "FirstLevelIconSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SecondLevelSections_SecondLevelSectionId",
                table: "Products",
                column: "SecondLevelSectionId",
                principalTable: "SecondLevelSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SecondLevelSections_FirstLevelImageSections_FirstLevelImageSectionId",
                table: "SecondLevelSections",
                column: "FirstLevelImageSectionId",
                principalTable: "FirstLevelImageSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirstLevelImageSections_FirstLevelIconSections_FirstLevelIconSectionId",
                table: "FirstLevelImageSections");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SecondLevelSections_SecondLevelSectionId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SecondLevelSections_FirstLevelImageSections_FirstLevelImageSectionId",
                table: "SecondLevelSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SecondLevelSections",
                table: "SecondLevelSections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FirstLevelImageSections",
                table: "FirstLevelImageSections");

            migrationBuilder.RenameTable(
                name: "SecondLevelSections",
                newName: "SecondLevelSection");

            migrationBuilder.RenameTable(
                name: "FirstLevelImageSections",
                newName: "FirstLevelImageSection");

            migrationBuilder.RenameIndex(
                name: "IX_SecondLevelSections_FirstLevelImageSectionId",
                table: "SecondLevelSection",
                newName: "IX_SecondLevelSection_FirstLevelImageSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_FirstLevelImageSections_FirstLevelIconSectionId",
                table: "FirstLevelImageSection",
                newName: "IX_FirstLevelImageSection_FirstLevelIconSectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecondLevelSection",
                table: "SecondLevelSection",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FirstLevelImageSection",
                table: "FirstLevelImageSection",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FirstLevelImageSection_FirstLevelIconSections_FirstLevelIconSectionId",
                table: "FirstLevelImageSection",
                column: "FirstLevelIconSectionId",
                principalTable: "FirstLevelIconSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SecondLevelSection_SecondLevelSectionId",
                table: "Products",
                column: "SecondLevelSectionId",
                principalTable: "SecondLevelSection",
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
    }
}
