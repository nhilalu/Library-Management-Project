using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagementProject.Data.Migrations
{
    public partial class CategoryNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryName",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryName",
                table: "Books");
        }
    }
}
