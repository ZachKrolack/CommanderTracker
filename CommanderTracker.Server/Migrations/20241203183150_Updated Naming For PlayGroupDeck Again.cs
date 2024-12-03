using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedNamingForPlayGroupDeckAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_play_group_decks_decks_decks_id",
                table: "play_group_decks");

            migrationBuilder.DropForeignKey(
                name: "FK_play_group_decks_play_groups_play_groups_id",
                table: "play_group_decks");

            migrationBuilder.RenameColumn(
                name: "play_groups_id",
                table: "play_group_decks",
                newName: "play_group_id");

            migrationBuilder.RenameColumn(
                name: "decks_id",
                table: "play_group_decks",
                newName: "deck_id");

            migrationBuilder.RenameIndex(
                name: "IX_play_group_decks_play_groups_id",
                table: "play_group_decks",
                newName: "IX_play_group_decks_play_group_id");

            migrationBuilder.RenameIndex(
                name: "IX_play_group_decks_decks_id",
                table: "play_group_decks",
                newName: "IX_play_group_decks_deck_id");

            migrationBuilder.AddForeignKey(
                name: "FK_play_group_decks_decks_deck_id",
                table: "play_group_decks",
                column: "deck_id",
                principalTable: "decks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_play_group_decks_play_groups_play_group_id",
                table: "play_group_decks",
                column: "play_group_id",
                principalTable: "play_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_play_group_decks_decks_deck_id",
                table: "play_group_decks");

            migrationBuilder.DropForeignKey(
                name: "FK_play_group_decks_play_groups_play_group_id",
                table: "play_group_decks");

            migrationBuilder.RenameColumn(
                name: "play_group_id",
                table: "play_group_decks",
                newName: "play_groups_id");

            migrationBuilder.RenameColumn(
                name: "deck_id",
                table: "play_group_decks",
                newName: "decks_id");

            migrationBuilder.RenameIndex(
                name: "IX_play_group_decks_play_group_id",
                table: "play_group_decks",
                newName: "IX_play_group_decks_play_groups_id");

            migrationBuilder.RenameIndex(
                name: "IX_play_group_decks_deck_id",
                table: "play_group_decks",
                newName: "IX_play_group_decks_decks_id");

            migrationBuilder.AddForeignKey(
                name: "FK_play_group_decks_decks_decks_id",
                table: "play_group_decks",
                column: "decks_id",
                principalTable: "decks",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_play_group_decks_play_groups_play_groups_id",
                table: "play_group_decks",
                column: "play_groups_id",
                principalTable: "play_groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
