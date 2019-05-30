using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagementProject.Data.Migrations
{
    public partial class Book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LendId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lend",
                columns: table => new
                {
                    LendId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lend", x => x.LendId);
                    table.ForeignKey(
                        name: "FK_Lend_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_LendId",
                table: "User",
                column: "LendId");

            migrationBuilder.CreateIndex(
                name: "IX_Lend_BookId",
                table: "Lend",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Lend_LendId",
                table: "User",
                column: "LendId",
                principalTable: "Lend",
                principalColumn: "LendId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Lend_LendId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Lend");

            migrationBuilder.DropIndex(
                name: "IX_User_LendId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LendId",
                table: "User");
        }
    }
}
