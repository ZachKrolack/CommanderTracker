using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedPlayGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d83aac67-5267-4847-9bf1-2f25767daa40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee1ef752-e757-4da4-831e-158bdf82d434");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "pilots",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayGroupId",
                table: "pilots",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "games",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayGroupId",
                table: "games",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "play_groups",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PilotIds = table.Column<List<Guid>>(type: "uuid[]", nullable: false),
                    CreatedById = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_play_groups", x => x.id);
                    table.ForeignKey(
                        name: "FK_play_groups_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31aef03a-acd1-40c6-bab6-b879f1ca89dd", null, "User", "USER" },
                    { "77d6f313-05d4-411c-a59b-3a9f3d7edd7a", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_pilots_CreatedById",
                table: "pilots",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_pilots_PlayGroupId",
                table: "pilots",
                column: "PlayGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_games_CreatedById",
                table: "games",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_games_PlayGroupId",
                table: "games",
                column: "PlayGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_play_groups_CreatedById",
                table: "play_groups",
                column: "CreatedById");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropTable(
                name: "play_groups");

            migrationBuilder.DropIndex(
                name: "IX_pilots_CreatedById",
                table: "pilots");

            migrationBuilder.DropIndex(
                name: "IX_pilots_PlayGroupId",
                table: "pilots");

            migrationBuilder.DropIndex(
                name: "IX_games_CreatedById",
                table: "games");

            migrationBuilder.DropIndex(
                name: "IX_games_PlayGroupId",
                table: "games");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31aef03a-acd1-40c6-bab6-b879f1ca89dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77d6f313-05d4-411c-a59b-3a9f3d7edd7a");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "pilots");

            migrationBuilder.DropColumn(
                name: "PlayGroupId",
                table: "pilots");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "games");

            migrationBuilder.DropColumn(
                name: "PlayGroupId",
                table: "games");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d83aac67-5267-4847-9bf1-2f25767daa40", null, "User", "USER" },
                    { "ee1ef752-e757-4da4-831e-158bdf82d434", null, "Admin", "ADMIN" }
                });
        }
    }
}
