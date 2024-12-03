using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedDeckPlayInstanceRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "deck_id",
                table: "play_instances",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_play_instances_decks_deck_id",
                table: "play_instances");

            migrationBuilder.DropIndex(
                name: "IX_play_instances_deck_id",
                table: "play_instances");

            migrationBuilder.DropColumn(
                name: "deck_id",
                table: "play_instances");
        }
    }
}
