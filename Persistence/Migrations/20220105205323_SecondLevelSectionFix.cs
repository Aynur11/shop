using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SecondLevelSectionFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SecondLevelSections_FirstLevelImageSectionId",
                table: "SecondLevelSections");

            migrationBuilder.CreateIndex(
                name: "IX_SecondLevelSections_FirstLevelImageSectionId",
                table: "SecondLevelSections",
                column: "FirstLevelImageSectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SecondLevelSections_FirstLevelImageSectionId",
                table: "SecondLevelSections");

            migrationBuilder.CreateIndex(
                name: "IX_SecondLevelSections_FirstLevelImageSectionId",
                table: "SecondLevelSections",
                column: "FirstLevelImageSectionId",
                unique: true);
        }
    }
}
