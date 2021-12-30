using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FK3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirstLevelImageSection_FirstLevelIconSection_FirstLevelIconSectionId",
                table: "FirstLevelImageSection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FirstLevelIconSection",
                table: "FirstLevelIconSection");

            migrationBuilder.RenameTable(
                name: "FirstLevelIconSection",
                newName: "FirstLevelIconSections");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FirstLevelIconSections",
                table: "FirstLevelIconSections",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FirstLevelImageSection_FirstLevelIconSections_FirstLevelIconSectionId",
                table: "FirstLevelImageSection",
                column: "FirstLevelIconSectionId",
                principalTable: "FirstLevelIconSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirstLevelImageSection_FirstLevelIconSections_FirstLevelIconSectionId",
                table: "FirstLevelImageSection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FirstLevelIconSections",
                table: "FirstLevelIconSections");

            migrationBuilder.RenameTable(
                name: "FirstLevelIconSections",
                newName: "FirstLevelIconSection");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FirstLevelIconSection",
                table: "FirstLevelIconSection",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FirstLevelImageSection_FirstLevelIconSection_FirstLevelIconSectionId",
                table: "FirstLevelImageSection",
                column: "FirstLevelIconSectionId",
                principalTable: "FirstLevelIconSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
