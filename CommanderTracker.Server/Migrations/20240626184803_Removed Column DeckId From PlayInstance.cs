using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class RemovedColumnDeckIdFromPlayInstance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_play_instances_decks_deck_id",
                table: "play_instances");

            migrationBuilder.DropIndex(
                name: "IX_play_instances_deck_id",
                table: "play_instances");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72263a74-c9dd-41d8-9165-ea7139f43a7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c37fbeef-035a-47e1-9384-a6847975be73");

            migrationBuilder.DropColumn(
                name: "deck_id",
                table: "play_instances");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d8201ec3-bc58-4438-80d8-67fa8f42db76", null, "User", "USER" },
                    { "ec541738-858f-476d-b169-9e85881dcb6f", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8201ec3-bc58-4438-80d8-67fa8f42db76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec541738-858f-476d-b169-9e85881dcb6f");

            migrationBuilder.AddColumn<Guid>(
                name: "deck_id",
                table: "play_instances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "72263a74-c9dd-41d8-9165-ea7139f43a7f", null, "User", "USER" },
                    { "c37fbeef-035a-47e1-9384-a6847975be73", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_play_instances_deck_id",
                table: "play_instances",
                column: "deck_id");

            migrationBuilder.AddForeignKey(
                name: "FK_play_instances_decks_deck_id",
                table: "play_instances",
                column: "deck_id",
                principalTable: "decks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
