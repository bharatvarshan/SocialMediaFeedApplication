using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaApplication.Migrations
{
    public partial class ModelModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Feeds_PostsFeedId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "PostsFeedId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Feeds_PostsFeedId",
                table: "Users",
                column: "PostsFeedId",
                principalTable: "Feeds",
                principalColumn: "FeedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Feeds_PostsFeedId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "PostsFeedId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Feeds_PostsFeedId",
                table: "Users",
                column: "PostsFeedId",
                principalTable: "Feeds",
                principalColumn: "FeedId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
