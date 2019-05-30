﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryManagementProject.Data.Migrations
{
    public partial class BooksChanged2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_AspNetUsers_LibraryUserId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_LibraryUserId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LibraryUserId",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LibraryUserId",
                table: "Books",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_LibraryUserId",
                table: "Books",
                column: "LibraryUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_AspNetUsers_LibraryUserId",
                table: "Books",
                column: "LibraryUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
