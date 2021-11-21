using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.Migrations
{
    public partial class full : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "album",
                table: "images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "images",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "album",
                table: "images");

            migrationBuilder.DropColumn(
                name: "image",
                table: "images");
        }
    }
}
