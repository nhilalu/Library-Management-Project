using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagementProject.Data.Migrations
{
    public partial class IdentityMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Categories_CategoryId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Lend_Book_BookId",
                table: "Lend");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lend",
                table: "Lend");

            migrationBuilder.DropIndex(
                name: "IX_Lend_BookId",
                table: "Lend");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Lend");

            migrationBuilder.RenameTable(
                name: "Lend",
                newName: "Lends");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Books",
                newName: "LibraryUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_CategoryId",
                table: "Books",
                newName: "IX_Books_CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LendDate",
                table: "Lends",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Lends",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LibraryUserId",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LendId",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lends",
                table: "Lends",
                column: "LendId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lends_UserId",
                table: "Lends",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LendId",
                table: "Books",
                column: "LendId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_LibraryUserId",
                table: "Books",
                column: "LibraryUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "AuthorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Lends_LendId",
                table: "Books",
                column: "LendId",
                principalTable: "Lends",
                principalColumn: "LendId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_LibraryUserId",
                table: "Books",
                column: "LibraryUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lends_AspNetUsers_UserId",
                table: "Lends",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Lends_LendId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_LibraryUserId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Lends_AspNetUsers_UserId",
                table: "Lends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lends",
                table: "Lends");

            migrationBuilder.DropIndex(
                name: "IX_Lends_UserId",
                table: "Lends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_AuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_LendId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_LibraryUserId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LendDate",
                table: "Lends");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Lends");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LendId",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Lends",
                newName: "Lend");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Book");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "LibraryUserId",
                table: "Book",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CategoryId",
                table: "Book",
                newName: "IX_Book_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Lend",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Book",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lend",
                table: "Lend",
                column: "LendId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "AuthorId");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookCount = table.Column<int>(nullable: false),
                    LendId = table.Column<int>(nullable: true),
                    UserAddress = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_Lend_LendId",
                        column: x => x.LendId,
                        principalTable: "Lend",
                        principalColumn: "LendId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lend_BookId",
                table: "Lend",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_User_LendId",
                table: "User",
                column: "LendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Categories_CategoryId",
                table: "Book",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lend_Book_BookId",
                table: "Lend",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
