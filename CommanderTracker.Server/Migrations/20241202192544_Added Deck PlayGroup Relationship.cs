using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedDeckPlayGroupRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeckPlayGroup");
        }
    }
}
