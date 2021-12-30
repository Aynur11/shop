using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FK2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SecondLevelSection_FirstLevelImageSectionId",
                table: "SecondLevelSection");

            migrationBuilder.CreateIndex(
                name: "IX_SecondLevelSection_FirstLevelImageSectionId",
                table: "SecondLevelSection",
                column: "FirstLevelImageSectionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SecondLevelSection_FirstLevelImageSectionId",
                table: "SecondLevelSection");

            migrationBuilder.CreateIndex(
                name: "IX_SecondLevelSection_FirstLevelImageSectionId",
                table: "SecondLevelSection",
                column: "FirstLevelImageSectionId");
        }
    }
}
