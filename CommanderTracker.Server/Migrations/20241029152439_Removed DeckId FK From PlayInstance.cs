using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class RemovedDeckIdFKFromPlayInstance : Migration
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
                keyValue: "252c9bf9-b5c0-4501-8014-b3728e46370c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4824fac-6415-47e0-bc4f-dd37f6f2402d");

            migrationBuilder.DropColumn(
                name: "deck_id",
                table: "play_instances");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46d28a08-f8ad-4ccb-828a-ed595fdd176d", null, "User", "USER" },
                    { "5bb69280-13a5-4279-84fe-1629e747b689", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46d28a08-f8ad-4ccb-828a-ed595fdd176d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bb69280-13a5-4279-84fe-1629e747b689");

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
                    { "252c9bf9-b5c0-4501-8014-b3728e46370c", null, "Admin", "ADMIN" },
                    { "e4824fac-6415-47e0-bc4f-dd37f6f2402d", null, "User", "USER" }
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
