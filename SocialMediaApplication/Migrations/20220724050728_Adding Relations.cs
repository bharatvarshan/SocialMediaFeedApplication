using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaApplication.Migrations
{
    public partial class AddingRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserId");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<int>(type: "int", nullable: false),
                    FeedId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Feeds_FeedId",
                        column: x => x.FeedId,
                        principalTable: "Feeds",
                        principalColumn: "FeedId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FeedId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Feeds_FeedId",
                        column: x => x.FeedId,
                        principalTable: "Feeds",
                        principalColumn: "FeedId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TaggedUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FeedId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaggedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaggedUsers_Feeds_FeedId",
                        column: x => x.FeedId,
                        principalTable: "Feeds",
                        principalColumn: "FeedId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FeedId",
                table: "Comments",
                column: "FeedId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_FeedId",
                table: "Likes",
                column: "FeedId");

            migrationBuilder.CreateIndex(
                name: "IX_TaggedUsers_FeedId",
                table: "TaggedUsers",
                column: "FeedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "TaggedUsers");

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
    }
}
