using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class EntityChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecondLevelSections_FirstLevelImageSections_FirstLevelImageSectionId",
                table: "SecondLevelSections");

            migrationBuilder.DropIndex(
                name: "IX_SecondLevelSections_FirstLevelImageSectionId",
                table: "SecondLevelSections");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FirstLevelImageSections",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddForeignKey(
                name: "FK_FirstLevelImageSections_SecondLevelSections_Id",
                table: "FirstLevelImageSections",
                column: "Id",
                principalTable: "SecondLevelSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirstLevelImageSections_SecondLevelSections_Id",
                table: "FirstLevelImageSections");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FirstLevelImageSections",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_SecondLevelSections_FirstLevelImageSectionId",
                table: "SecondLevelSections",
                column: "FirstLevelImageSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SecondLevelSections_FirstLevelImageSections_FirstLevelImageSectionId",
                table: "SecondLevelSections",
                column: "FirstLevelImageSectionId",
                principalTable: "FirstLevelImageSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
