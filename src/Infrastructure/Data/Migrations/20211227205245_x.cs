using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class x : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StyleId",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_StyleId",
                table: "Products",
                column: "StyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Styles_StyleId",
                table: "Products",
                column: "StyleId",
                principalTable: "Styles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Styles_StyleId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StyleId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StyleId",
                table: "Products");
        }
    }
}
