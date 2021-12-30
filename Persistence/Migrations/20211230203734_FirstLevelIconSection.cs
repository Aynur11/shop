using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FirstLevelIconSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_SecondLevelSectionId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "FirstLevelIconSectionId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstLevelIconSectionId",
                table: "FirstLevelImageSection",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FirstLevelIconSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IconPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstLevelIconSection", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_FirstLevelIconSectionId",
                table: "Products",
                column: "FirstLevelIconSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SecondLevelSectionId",
                table: "Products",
                column: "SecondLevelSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FirstLevelImageSection_FirstLevelIconSectionId",
                table: "FirstLevelImageSection",
                column: "FirstLevelIconSectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FirstLevelImageSection_FirstLevelIconSection_FirstLevelIconSectionId",
                table: "FirstLevelImageSection",
                column: "FirstLevelIconSectionId",
                principalTable: "FirstLevelIconSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FirstLevelIconSection_FirstLevelIconSectionId",
                table: "Products",
                column: "FirstLevelIconSectionId",
                principalTable: "FirstLevelIconSection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FirstLevelImageSection_FirstLevelIconSection_FirstLevelIconSectionId",
                table: "FirstLevelImageSection");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_FirstLevelIconSection_FirstLevelIconSectionId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "FirstLevelIconSection");

            migrationBuilder.DropIndex(
                name: "IX_Products_FirstLevelIconSectionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SecondLevelSectionId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_FirstLevelImageSection_FirstLevelIconSectionId",
                table: "FirstLevelImageSection");

            migrationBuilder.DropColumn(
                name: "FirstLevelIconSectionId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FirstLevelIconSectionId",
                table: "FirstLevelImageSection");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SecondLevelSectionId",
                table: "Products",
                column: "SecondLevelSectionId",
                unique: true);
        }
    }
}
