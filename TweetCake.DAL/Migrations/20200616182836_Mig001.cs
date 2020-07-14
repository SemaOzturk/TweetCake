using Microsoft.EntityFrameworkCore.Migrations;

namespace TweetCake.DAL.Migrations
{
    public partial class Mig001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConfirm",
                table: "UserFriend",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirm",
                table: "UserFriend");
        }
    }
}
