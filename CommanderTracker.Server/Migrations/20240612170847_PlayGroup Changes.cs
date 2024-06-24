using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class PlayGroupChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_decks_AspNetUsers_CreatedById",
                table: "decks");

            migrationBuilder.DropForeignKey(
                name: "FK_games_AspNetUsers_CreatedById",
                table: "games");

            migrationBuilder.DropForeignKey(
                name: "FK_games_play_groups_PlayGroupId",
                table: "games");

            migrationBuilder.DropForeignKey(
                name: "FK_pilots_AspNetUsers_CreatedById",
                table: "pilots");

            migrationBuilder.DropForeignKey(
                name: "FK_pilots_play_groups_PlayGroupId",
                table: "pilots");

            migrationBuilder.DropForeignKey(
                name: "FK_play_groups_AspNetUsers_CreatedById",
                table: "play_groups");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31aef03a-acd1-40c6-bab6-b879f1ca89dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77d6f313-05d4-411c-a59b-3a9f3d7edd7a");

            migrationBuilder.DropColumn(
                name: "PilotIds",
                table: "play_groups");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "play_groups",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "play_groups",
                newName: "created_by_id");

            migrationBuilder.RenameIndex(
                name: "IX_play_groups_CreatedById",
                table: "play_groups",
                newName: "IX_play_groups_created_by_id");

            migrationBuilder.RenameColumn(
                name: "PlayGroupId",
                table: "pilots",
                newName: "play_group_id");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "pilots",
                newName: "created_by_id");

            migrationBuilder.RenameIndex(
                name: "IX_pilots_PlayGroupId",
                table: "pilots",
                newName: "IX_pilots_play_group_id");

            migrationBuilder.RenameIndex(
                name: "IX_pilots_CreatedById",
                table: "pilots",
                newName: "IX_pilots_created_by_id");

            migrationBuilder.RenameColumn(
                name: "PlayGroupId",
                table: "games",
                newName: "play_group_id");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "games",
                newName: "created_by_id");

            migrationBuilder.RenameIndex(
                name: "IX_games_PlayGroupId",
                table: "games",
                newName: "IX_games_play_group_id");

            migrationBuilder.RenameIndex(
                name: "IX_games_CreatedById",
                table: "games",
                newName: "IX_games_created_by_id");

            migrationBuilder.RenameColumn(
                name: "CreatedById",
                table: "decks",
                newName: "created_by_id");

            migrationBuilder.RenameIndex(
                name: "IX_decks_CreatedById",
                table: "decks",
                newName: "IX_decks_created_by_id");

            migrationBuilder.AddColumn<string>(
                name: "created_by_id",
                table: "play_instances",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updated_by_id",
                table: "play_instances",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updated_by_id",
                table: "play_groups",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "app_user_id",
                table: "pilots",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by_id",
                table: "pilots",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updated_by_id",
                table: "games",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updated_by_id",
                table: "decks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "583ab045-9e02-45b8-bb9a-035e398b75db", null, "User", "USER" },
                    { "66abeb1a-fc73-4c77-9c57-c1470cb216c2", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_play_instances_created_by_id",
                table: "play_instances",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_play_instances_updated_by_id",
                table: "play_instances",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_play_groups_updated_by_id",
                table: "play_groups",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_pilots_app_user_id",
                table: "pilots",
                column: "app_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_pilots_updated_by_id",
                table: "pilots",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_games_updated_by_id",
                table: "games",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_decks_updated_by_id",
                table: "decks",
                column: "updated_by_id");

            migrationBuilder.AddForeignKey(
                name: "FK_decks_AspNetUsers_created_by_id",
                table: "decks",
                column: "created_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_decks_AspNetUsers_updated_by_id",
                table: "decks",
                column: "updated_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_games_AspNetUsers_created_by_id",
                table: "games",
                column: "created_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_games_AspNetUsers_updated_by_id",
                table: "games",
                column: "updated_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_games_play_groups_play_group_id",
                table: "games",
                column: "play_group_id",
                principalTable: "play_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pilots_AspNetUsers_app_user_id",
                table: "pilots",
                column: "app_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pilots_AspNetUsers_created_by_id",
                table: "pilots",
                column: "created_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pilots_AspNetUsers_updated_by_id",
                table: "pilots",
                column: "updated_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pilots_play_groups_play_group_id",
                table: "pilots",
                column: "play_group_id",
                principalTable: "play_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_play_groups_AspNetUsers_created_by_id",
                table: "play_groups",
                column: "created_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_play_groups_AspNetUsers_updated_by_id",
                table: "play_groups",
                column: "updated_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_play_instances_AspNetUsers_created_by_id",
                table: "play_instances",
                column: "created_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_play_instances_AspNetUsers_updated_by_id",
                table: "play_instances",
                column: "updated_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_decks_AspNetUsers_created_by_id",
                table: "decks");

            migrationBuilder.DropForeignKey(
                name: "FK_decks_AspNetUsers_updated_by_id",
                table: "decks");

            migrationBuilder.DropForeignKey(
                name: "FK_games_AspNetUsers_created_by_id",
                table: "games");

            migrationBuilder.DropForeignKey(
                name: "FK_games_AspNetUsers_updated_by_id",
                table: "games");

            migrationBuilder.DropForeignKey(
                name: "FK_games_play_groups_play_group_id",
                table: "games");

            migrationBuilder.DropForeignKey(
                name: "FK_pilots_AspNetUsers_app_user_id",
                table: "pilots");

            migrationBuilder.DropForeignKey(
                name: "FK_pilots_AspNetUsers_created_by_id",
                table: "pilots");

            migrationBuilder.DropForeignKey(
                name: "FK_pilots_AspNetUsers_updated_by_id",
                table: "pilots");

            migrationBuilder.DropForeignKey(
                name: "FK_pilots_play_groups_play_group_id",
                table: "pilots");

            migrationBuilder.DropForeignKey(
                name: "FK_play_groups_AspNetUsers_created_by_id",
                table: "play_groups");

            migrationBuilder.DropForeignKey(
                name: "FK_play_groups_AspNetUsers_updated_by_id",
                table: "play_groups");

            migrationBuilder.DropForeignKey(
                name: "FK_play_instances_AspNetUsers_created_by_id",
                table: "play_instances");

            migrationBuilder.DropForeignKey(
                name: "FK_play_instances_AspNetUsers_updated_by_id",
                table: "play_instances");

            migrationBuilder.DropIndex(
                name: "IX_play_instances_created_by_id",
                table: "play_instances");

            migrationBuilder.DropIndex(
                name: "IX_play_instances_updated_by_id",
                table: "play_instances");

            migrationBuilder.DropIndex(
                name: "IX_play_groups_updated_by_id",
                table: "play_groups");

            migrationBuilder.DropIndex(
                name: "IX_pilots_app_user_id",
                table: "pilots");

            migrationBuilder.DropIndex(
                name: "IX_pilots_updated_by_id",
                table: "pilots");

            migrationBuilder.DropIndex(
                name: "IX_games_updated_by_id",
                table: "games");

            migrationBuilder.DropIndex(
                name: "IX_decks_updated_by_id",
                table: "decks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "583ab045-9e02-45b8-bb9a-035e398b75db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66abeb1a-fc73-4c77-9c57-c1470cb216c2");

            migrationBuilder.DropColumn(
                name: "created_by_id",
                table: "play_instances");

            migrationBuilder.DropColumn(
                name: "updated_by_id",
                table: "play_instances");

            migrationBuilder.DropColumn(
                name: "updated_by_id",
                table: "play_groups");

            migrationBuilder.DropColumn(
                name: "app_user_id",
                table: "pilots");

            migrationBuilder.DropColumn(
                name: "updated_by_id",
                table: "pilots");

            migrationBuilder.DropColumn(
                name: "updated_by_id",
                table: "games");

            migrationBuilder.DropColumn(
                name: "updated_by_id",
                table: "decks");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "play_groups",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                table: "play_groups",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_play_groups_created_by_id",
                table: "play_groups",
                newName: "IX_play_groups_CreatedById");

            migrationBuilder.RenameColumn(
                name: "play_group_id",
                table: "pilots",
                newName: "PlayGroupId");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                table: "pilots",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_pilots_play_group_id",
                table: "pilots",
                newName: "IX_pilots_PlayGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_pilots_created_by_id",
                table: "pilots",
                newName: "IX_pilots_CreatedById");

            migrationBuilder.RenameColumn(
                name: "play_group_id",
                table: "games",
                newName: "PlayGroupId");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                table: "games",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_games_play_group_id",
                table: "games",
                newName: "IX_games_PlayGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_games_created_by_id",
                table: "games",
                newName: "IX_games_CreatedById");

            migrationBuilder.RenameColumn(
                name: "created_by_id",
                table: "decks",
                newName: "CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_decks_created_by_id",
                table: "decks",
                newName: "IX_decks_CreatedById");

            migrationBuilder.AddColumn<List<Guid>>(
                name: "PilotIds",
                table: "play_groups",
                type: "uuid[]",
                nullable: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31aef03a-acd1-40c6-bab6-b879f1ca89dd", null, "User", "USER" },
                    { "77d6f313-05d4-411c-a59b-3a9f3d7edd7a", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_decks_AspNetUsers_CreatedById",
                table: "decks",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_games_AspNetUsers_CreatedById",
                table: "games",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_games_play_groups_PlayGroupId",
                table: "games",
                column: "PlayGroupId",
                principalTable: "play_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pilots_AspNetUsers_CreatedById",
                table: "pilots",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pilots_play_groups_PlayGroupId",
                table: "pilots",
                column: "PlayGroupId",
                principalTable: "play_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_play_groups_AspNetUsers_CreatedById",
                table: "play_groups",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
