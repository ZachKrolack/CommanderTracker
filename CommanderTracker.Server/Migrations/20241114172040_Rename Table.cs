using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayGroupAppUser_AspNetUsers_app_user_id",
                table: "PlayGroupAppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayGroupAppUser_AspNetUsers_created_by_id",
                table: "PlayGroupAppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayGroupAppUser_AspNetUsers_updated_by_id",
                table: "PlayGroupAppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayGroupAppUser_play_groups_play_group_id",
                table: "PlayGroupAppUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayGroupAppUser",
                table: "PlayGroupAppUser");

            migrationBuilder.RenameTable(
                name: "PlayGroupAppUser",
                newName: "play_group_app_users");

            migrationBuilder.RenameIndex(
                name: "IX_PlayGroupAppUser_updated_by_id",
                table: "play_group_app_users",
                newName: "IX_play_group_app_users_updated_by_id");

            migrationBuilder.RenameIndex(
                name: "IX_PlayGroupAppUser_play_group_id",
                table: "play_group_app_users",
                newName: "IX_play_group_app_users_play_group_id");

            migrationBuilder.RenameIndex(
                name: "IX_PlayGroupAppUser_created_by_id",
                table: "play_group_app_users",
                newName: "IX_play_group_app_users_created_by_id");

            migrationBuilder.RenameIndex(
                name: "IX_PlayGroupAppUser_app_user_id",
                table: "play_group_app_users",
                newName: "IX_play_group_app_users_app_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_play_group_app_users",
                table: "play_group_app_users",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_play_group_app_users_AspNetUsers_app_user_id",
                table: "play_group_app_users",
                column: "app_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_play_group_app_users_AspNetUsers_created_by_id",
                table: "play_group_app_users",
                column: "created_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_play_group_app_users_AspNetUsers_updated_by_id",
                table: "play_group_app_users",
                column: "updated_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_play_group_app_users_play_groups_play_group_id",
                table: "play_group_app_users",
                column: "play_group_id",
                principalTable: "play_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_play_group_app_users_AspNetUsers_app_user_id",
                table: "play_group_app_users");

            migrationBuilder.DropForeignKey(
                name: "FK_play_group_app_users_AspNetUsers_created_by_id",
                table: "play_group_app_users");

            migrationBuilder.DropForeignKey(
                name: "FK_play_group_app_users_AspNetUsers_updated_by_id",
                table: "play_group_app_users");

            migrationBuilder.DropForeignKey(
                name: "FK_play_group_app_users_play_groups_play_group_id",
                table: "play_group_app_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_play_group_app_users",
                table: "play_group_app_users");

            migrationBuilder.RenameTable(
                name: "play_group_app_users",
                newName: "PlayGroupAppUser");

            migrationBuilder.RenameIndex(
                name: "IX_play_group_app_users_updated_by_id",
                table: "PlayGroupAppUser",
                newName: "IX_PlayGroupAppUser_updated_by_id");

            migrationBuilder.RenameIndex(
                name: "IX_play_group_app_users_play_group_id",
                table: "PlayGroupAppUser",
                newName: "IX_PlayGroupAppUser_play_group_id");

            migrationBuilder.RenameIndex(
                name: "IX_play_group_app_users_created_by_id",
                table: "PlayGroupAppUser",
                newName: "IX_PlayGroupAppUser_created_by_id");

            migrationBuilder.RenameIndex(
                name: "IX_play_group_app_users_app_user_id",
                table: "PlayGroupAppUser",
                newName: "IX_PlayGroupAppUser_app_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayGroupAppUser",
                table: "PlayGroupAppUser",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayGroupAppUser_AspNetUsers_app_user_id",
                table: "PlayGroupAppUser",
                column: "app_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayGroupAppUser_AspNetUsers_created_by_id",
                table: "PlayGroupAppUser",
                column: "created_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayGroupAppUser_AspNetUsers_updated_by_id",
                table: "PlayGroupAppUser",
                column: "updated_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayGroupAppUser_play_groups_play_group_id",
                table: "PlayGroupAppUser",
                column: "play_group_id",
                principalTable: "play_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
