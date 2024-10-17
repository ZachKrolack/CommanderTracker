using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPlayInstancePlayGroupDeckIdColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_play_instances_play_group_decks_PlayGroupDeckId",
                table: "play_instances");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "246eaf79-c68b-4947-9790-57f876fef8fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d82e2271-b655-478b-98be-dd7a61c4e58b");

            migrationBuilder.RenameColumn(
                name: "PlayGroupDeckId",
                table: "play_instances",
                newName: "play_group_deck_id");

            migrationBuilder.RenameIndex(
                name: "IX_play_instances_PlayGroupDeckId",
                table: "play_instances",
                newName: "IX_play_instances_play_group_deck_id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "play_group_deck_id",
                table: "play_instances",
                newName: "PlayGroupDeckId");

            migrationBuilder.RenameIndex(
                name: "IX_play_instances_play_group_deck_id",
                table: "play_instances",
                newName: "IX_play_instances_PlayGroupDeckId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "246eaf79-c68b-4947-9790-57f876fef8fd", null, "Admin", "ADMIN" },
                    { "d82e2271-b655-478b-98be-dd7a61c4e58b", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_play_instances_play_group_decks_PlayGroupDeckId",
                table: "play_instances",
                column: "PlayGroupDeckId",
                principalTable: "play_group_decks",
                principalColumn: "id");
        }
    }
}
