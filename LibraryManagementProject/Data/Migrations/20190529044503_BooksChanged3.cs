using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagementProject.Data.Migrations
{
    public partial class BooksChanged3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Lends_LendId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_LendId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "LendId",
                table: "Books",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Books_LendId",
                table: "Books",
                column: "LendId",
                unique: true,
                filter: "[LendId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Lends_LendId",
                table: "Books",
                column: "LendId",
                principalTable: "Lends",
                principalColumn: "LendId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Lends_LendId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_LendId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "LendId",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_LendId",
                table: "Books",
                column: "LendId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Lends_LendId",
                table: "Books",
                column: "LendId",
                principalTable: "Lends",
                principalColumn: "LendId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
