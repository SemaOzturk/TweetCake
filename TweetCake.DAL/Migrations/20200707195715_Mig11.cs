using Microsoft.EntityFrameworkCore.Migrations;

namespace TweetCake.DAL.Migrations
{
    public partial class Mig11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriend_Users_FriendId",
                table: "UserFriend");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriend_Users_UserId",
                table: "UserFriend");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFriend",
                table: "UserFriend");

            migrationBuilder.RenameTable(
                name: "UserFriend",
                newName: "UserFriends");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriend_UserId",
                table: "UserFriends",
                newName: "IX_UserFriends_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriend_FriendId",
                table: "UserFriends",
                newName: "IX_UserFriends_FriendId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserFriends",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FriendId",
                table: "UserFriends",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFriends",
                table: "UserFriends",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_Users_FriendId",
                table: "UserFriends",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_Users_UserId",
                table: "UserFriends",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_Users_FriendId",
                table: "UserFriends");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_Users_UserId",
                table: "UserFriends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFriends",
                table: "UserFriends");

            migrationBuilder.RenameTable(
                name: "UserFriends",
                newName: "UserFriend");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriends_UserId",
                table: "UserFriend",
                newName: "IX_UserFriend_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriends_FriendId",
                table: "UserFriend",
                newName: "IX_UserFriend_FriendId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserFriend",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FriendId",
                table: "UserFriend",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFriend",
                table: "UserFriend",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriend_Users_FriendId",
                table: "UserFriend",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriend_Users_UserId",
                table: "UserFriend",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
