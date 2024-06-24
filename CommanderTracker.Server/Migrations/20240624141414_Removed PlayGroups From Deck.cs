using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class RemovedPlayGroupsFromDeck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_play_groups_decks_DeckId",
                table: "play_groups");

            migrationBuilder.DropIndex(
                name: "IX_play_groups_DeckId",
                table: "play_groups");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ef79c43-18e6-49d0-a758-c45956591734");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3e3a9d0-e25f-42e3-a31e-1b09e56f7fb4");

            migrationBuilder.DropColumn(
                name: "DeckId",
                table: "play_groups");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e1f61c9-068d-45d0-a595-22966387f096", null, "Admin", "ADMIN" },
                    { "fc119ebe-682f-41f1-8589-8edf74fda0e0", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e1f61c9-068d-45d0-a595-22966387f096");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc119ebe-682f-41f1-8589-8edf74fda0e0");

            migrationBuilder.AddColumn<Guid>(
                name: "DeckId",
                table: "play_groups",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ef79c43-18e6-49d0-a758-c45956591734", null, "User", "USER" },
                    { "d3e3a9d0-e25f-42e3-a31e-1b09e56f7fb4", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_play_groups_DeckId",
                table: "play_groups",
                column: "DeckId");

            migrationBuilder.AddForeignKey(
                name: "FK_play_groups_decks_DeckId",
                table: "play_groups",
                column: "DeckId",
                principalTable: "decks",
                principalColumn: "id");
        }
    }
}
