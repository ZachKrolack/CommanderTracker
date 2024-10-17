using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPlayInstancePlayGroupDeckIdNonNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_play_instances_play_group_decks_play_group_deck_id",
                table: "play_instances");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4727610a-0528-4df0-9f2d-56f076849721");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "897dde22-b6d2-4f3a-89d8-47f76e65d808");

            migrationBuilder.AlterColumn<Guid>(
                name: "play_group_deck_id",
                table: "play_instances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "72263a74-c9dd-41d8-9165-ea7139f43a7f", null, "User", "USER" },
                    { "c37fbeef-035a-47e1-9384-a6847975be73", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_play_instances_play_group_decks_play_group_deck_id",
                table: "play_instances",
                column: "play_group_deck_id",
                principalTable: "play_group_decks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_play_instances_play_group_decks_play_group_deck_id",
                table: "play_instances");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72263a74-c9dd-41d8-9165-ea7139f43a7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c37fbeef-035a-47e1-9384-a6847975be73");

            migrationBuilder.AlterColumn<Guid>(
                name: "play_group_deck_id",
                table: "play_instances",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4727610a-0528-4df0-9f2d-56f076849721", null, "User", "USER" },
                    { "897dde22-b6d2-4f3a-89d8-47f76e65d808", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_play_instances_play_group_decks_play_group_deck_id",
                table: "play_instances",
                column: "play_group_deck_id",
                principalTable: "play_group_decks",
                principalColumn: "id");
        }
    }
}
