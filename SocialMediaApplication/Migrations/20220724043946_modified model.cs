using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaApplication.Migrations
{
    public partial class modifiedmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Feeds_PostsFeedId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PostsFeedId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PostsFeedId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Feeds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_UserId",
                table: "Feeds",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Users_UserId",
                table: "Feeds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Users_UserId",
                table: "Feeds");

            migrationBuilder.DropIndex(
                name: "IX_Feeds_UserId",
                table: "Feeds");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Feeds");

            migrationBuilder.AddColumn<int>(
                name: "PostsFeedId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PostsFeedId",
                table: "Users",
                column: "PostsFeedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Feeds_PostsFeedId",
                table: "Users",
                column: "PostsFeedId",
                principalTable: "Feeds",
                principalColumn: "FeedId");
        }
    }
}
