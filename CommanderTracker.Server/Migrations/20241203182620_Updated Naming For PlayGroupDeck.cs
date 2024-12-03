using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedNamingForPlayGroupDeck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_play_group_decks_decks_deck_id",
                table: "play_group_decks");

            migrationBuilder.DropForeignKey(
                name: "FK_play_group_decks_play_groups_play_group_id",
                table: "play_group_decks");

            migrationBuilder.DropTable(
                name: "DeckPlayGroup");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "DeckPlayGroup",
                columns: table => new
                {
                    DecksId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayGroupsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckPlayGroup", x => new { x.DecksId, x.PlayGroupsId });
                    table.ForeignKey(
                        name: "FK_DeckPlayGroup_decks_DecksId",
                        column: x => x.DecksId,
                        principalTable: "decks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeckPlayGroup_play_groups_PlayGroupsId",
                        column: x => x.PlayGroupsId,
                        principalTable: "play_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeckPlayGroup_PlayGroupsId",
                table: "DeckPlayGroup",
                column: "PlayGroupsId");

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
    }
}
