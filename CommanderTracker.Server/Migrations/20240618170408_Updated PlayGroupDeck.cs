using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPlayGroupDeck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b4391e9-b523-4df0-b504-6aff2248f596");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "656f5762-72c8-47dd-8d90-a30c6528b780");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PlayGroupDecks",
                newName: "id");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayGroupDeckId",
                table: "play_instances",
                type: "uuid",
                nullable: true);

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
                name: "IX_play_instances_PlayGroupDeckId",
                table: "play_instances",
                column: "PlayGroupDeckId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_play_instances_PlayGroupDecks_PlayGroupDeckId",
                table: "play_instances",
                column: "PlayGroupDeckId",
                principalTable: "PlayGroupDecks",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_play_groups_decks_DeckId",
                table: "play_groups");

            migrationBuilder.DropForeignKey(
                name: "FK_play_instances_PlayGroupDecks_PlayGroupDeckId",
                table: "play_instances");

            migrationBuilder.DropIndex(
                name: "IX_play_instances_PlayGroupDeckId",
                table: "play_instances");

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
                name: "PlayGroupDeckId",
                table: "play_instances");

            migrationBuilder.DropColumn(
                name: "DeckId",
                table: "play_groups");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PlayGroupDecks",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b4391e9-b523-4df0-b504-6aff2248f596", null, "Admin", "ADMIN" },
                    { "656f5762-72c8-47dd-8d90-a30c6528b780", null, "User", "USER" }
                });
        }
    }
}
