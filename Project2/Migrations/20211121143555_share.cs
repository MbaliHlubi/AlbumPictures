using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project2.Migrations
{
    public partial class share : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shareImages",
                columns: table => new
                {
                    sent_to = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    person_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    image_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shareImages", x => x.sent_to);
                    table.ForeignKey(
                        name: "FK_shareImages_images_image_id",
                        column: x => x.image_id,
                        principalTable: "images",
                        principalColumn: "image_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shareImages_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shareImages_image_id",
                table: "shareImages",
                column: "image_id");

            migrationBuilder.CreateIndex(
                name: "IX_shareImages_person_id",
                table: "shareImages",
                column: "person_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shareImages");
        }
    }
}
