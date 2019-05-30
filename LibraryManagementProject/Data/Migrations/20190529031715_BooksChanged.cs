using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagementProject.Data.Migrations
{
    public partial class BooksChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoriesName",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Book",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Categories_CategoryId",
                table: "Book",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Categories_CategoryId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_CategoryId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "CategoriesName");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "CategoriesId");
        }
    }
}
