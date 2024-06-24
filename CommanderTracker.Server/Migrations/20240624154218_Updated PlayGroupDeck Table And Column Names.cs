using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPlayGroupDeckTableAndColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_play_instances_PlayGroupDecks_PlayGroupDeckId",
                table: "play_instances");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayGroupDecks_AspNetUsers_created_by_id",
                table: "PlayGroupDecks");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayGroupDecks_AspNetUsers_updated_by_id",
                table: "PlayGroupDecks");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayGroupDecks_decks_DeckId",
                table: "PlayGroupDecks");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayGroupDecks_pilots_PilotId",
                table: "PlayGroupDecks");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayGroupDecks_play_groups_PlayGroupId",
                table: "PlayGroupDecks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayGroupDecks",
                table: "PlayGroupDecks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a544bd44-23a1-492c-960f-e59efd6392f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4dbe3b5-52a0-4586-bfcb-aee760c052cb");

            migrationBuilder.RenameTable(
                name: "PlayGroupDecks",
                newName: "play_group_decks");

            migrationBuilder.RenameColumn(
                name: "PlayGroupId",
                table: "play_group_decks",
                newName: "play_group_id");

            migrationBuilder.RenameColumn(
                name: "PilotId",
                table: "play_group_decks",
                newName: "pilot_id");

            migrationBuilder.RenameColumn(
                name: "DeckId",
                table: "play_group_decks",
                newName: "deck_id");

            migrationBuilder.RenameIndex(
                name: "IX_PlayGroupDecks_updated_by_id",
                table: "play_group_decks",
                newName: "IX_play_group_decks_updated_by_id");

            migrationBuilder.RenameIndex(
                name: "IX_PlayGroupDecks_PlayGroupId",
                table: "play_group_decks",
                newName: "IX_play_group_decks_play_group_id");

            migrationBuilder.RenameIndex(
                name: "IX_PlayGroupDecks_PilotId",
                table: "play_group_decks",
                newName: "IX_play_group_decks_pilot_id");

            migrationBuilder.RenameIndex(
                name: "IX_PlayGroupDecks_DeckId",
                table: "play_group_decks",
                newName: "IX_play_group_decks_deck_id");

            migrationBuilder.RenameIndex(
                name: "IX_PlayGroupDecks_created_by_id",
                table: "play_group_decks",
                newName: "IX_play_group_decks_created_by_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_play_group_decks",
                table: "play_group_decks",
                column: "id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "246eaf79-c68b-4947-9790-57f876fef8fd", null, "Admin", "ADMIN" },
                    { "d82e2271-b655-478b-98be-dd7a61c4e58b", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_play_group_decks_AspNetUsers_created_by_id",
                table: "play_group_decks",
                column: "created_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_play_group_decks_AspNetUsers_updated_by_id",
                table: "play_group_decks",
                column: "updated_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_play_group_decks_decks_deck_id",
                table: "play_group_decks",
                column: "deck_id",
                principalTable: "decks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_play_group_decks_pilots_pilot_id",
                table: "play_group_decks",
                column: "pilot_id",
                principalTable: "pilots",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_play_group_decks_play_groups_play_group_id",
                table: "play_group_decks",
                column: "play_group_id",
                principalTable: "play_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_play_instances_play_group_decks_PlayGroupDeckId",
                table: "play_instances",
                column: "PlayGroupDeckId",
                principalTable: "play_group_decks",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_play_group_decks_AspNetUsers_created_by_id",
                table: "play_group_decks");

            migrationBuilder.DropForeignKey(
                name: "FK_play_group_decks_AspNetUsers_updated_by_id",
                table: "play_group_decks");

            migrationBuilder.DropForeignKey(
                name: "FK_play_group_decks_decks_deck_id",
                table: "play_group_decks");

            migrationBuilder.DropForeignKey(
                name: "FK_play_group_decks_pilots_pilot_id",
                table: "play_group_decks");

            migrationBuilder.DropForeignKey(
                name: "FK_play_group_decks_play_groups_play_group_id",
                table: "play_group_decks");

            migrationBuilder.DropForeignKey(
                name: "FK_play_instances_play_group_decks_PlayGroupDeckId",
                table: "play_instances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_play_group_decks",
                table: "play_group_decks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "246eaf79-c68b-4947-9790-57f876fef8fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d82e2271-b655-478b-98be-dd7a61c4e58b");

            migrationBuilder.RenameTable(
                name: "play_group_decks",
                newName: "PlayGroupDecks");

            migrationBuilder.RenameColumn(
                name: "play_group_id",
                table: "PlayGroupDecks",
                newName: "PlayGroupId");

            migrationBuilder.RenameColumn(
                name: "pilot_id",
                table: "PlayGroupDecks",
                newName: "PilotId");

            migrationBuilder.RenameColumn(
                name: "deck_id",
                table: "PlayGroupDecks",
                newName: "DeckId");

            migrationBuilder.RenameIndex(
                name: "IX_play_group_decks_updated_by_id",
                table: "PlayGroupDecks",
                newName: "IX_PlayGroupDecks_updated_by_id");

            migrationBuilder.RenameIndex(
                name: "IX_play_group_decks_play_group_id",
                table: "PlayGroupDecks",
                newName: "IX_PlayGroupDecks_PlayGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_play_group_decks_pilot_id",
                table: "PlayGroupDecks",
                newName: "IX_PlayGroupDecks_PilotId");

            migrationBuilder.RenameIndex(
                name: "IX_play_group_decks_deck_id",
                table: "PlayGroupDecks",
                newName: "IX_PlayGroupDecks_DeckId");

            migrationBuilder.RenameIndex(
                name: "IX_play_group_decks_created_by_id",
                table: "PlayGroupDecks",
                newName: "IX_PlayGroupDecks_created_by_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayGroupDecks",
                table: "PlayGroupDecks",
                column: "id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a544bd44-23a1-492c-960f-e59efd6392f1", null, "Admin", "ADMIN" },
                    { "e4dbe3b5-52a0-4586-bfcb-aee760c052cb", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_play_instances_PlayGroupDecks_PlayGroupDeckId",
                table: "play_instances",
                column: "PlayGroupDeckId",
                principalTable: "PlayGroupDecks",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayGroupDecks_AspNetUsers_created_by_id",
                table: "PlayGroupDecks",
                column: "created_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayGroupDecks_AspNetUsers_updated_by_id",
                table: "PlayGroupDecks",
                column: "updated_by_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayGroupDecks_decks_DeckId",
                table: "PlayGroupDecks",
                column: "DeckId",
                principalTable: "decks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayGroupDecks_pilots_PilotId",
                table: "PlayGroupDecks",
                column: "PilotId",
                principalTable: "pilots",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayGroupDecks_play_groups_PlayGroupId",
                table: "PlayGroupDecks",
                column: "PlayGroupId",
                principalTable: "play_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
