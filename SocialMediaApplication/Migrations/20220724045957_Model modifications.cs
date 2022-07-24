using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaApplication.Migrations
{
    public partial class Modelmodifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comments",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "LikedBy",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "TaggedUsers",
                table: "Feeds");

            migrationBuilder.CreateTable(
                name: "UserId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FeedId = table.Column<int>(type: "int", nullable: true),
                    FeedId1 = table.Column<int>(type: "int", nullable: true),
                    FeedId2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserId_Feeds_FeedId",
                        column: x => x.FeedId,
                        principalTable: "Feeds",
                        principalColumn: "FeedId");
                    table.ForeignKey(
                        name: "FK_UserId_Feeds_FeedId1",
                        column: x => x.FeedId1,
                        principalTable: "Feeds",
                        principalColumn: "FeedId");
                    table.ForeignKey(
                        name: "FK_UserId_Feeds_FeedId2",
                        column: x => x.FeedId2,
                        principalTable: "Feeds",
                        principalColumn: "FeedId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserId_FeedId",
                table: "UserId",
                column: "FeedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserId_FeedId1",
                table: "UserId",
                column: "FeedId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserId_FeedId2",
                table: "UserId",
                column: "FeedId2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "Feeds",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LikedBy",
                table: "Feeds",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TaggedUsers",
                table: "Feeds",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
