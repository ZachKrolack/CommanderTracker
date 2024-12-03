using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class TestingPlayGroupDeckChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_play_group_decks_pilots_pilot_id",
                table: "play_group_decks");

            migrationBuilder.DropIndex(
                name: "IX_play_group_decks_pilot_id",
                table: "play_group_decks");

            migrationBuilder.DropColumn(
                name: "pilot_id",
                table: "play_group_decks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "pilot_id",
                table: "play_group_decks",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_play_group_decks_pilot_id",
                table: "play_group_decks",
                column: "pilot_id");

            migrationBuilder.AddForeignKey(
                name: "FK_play_group_decks_pilots_pilot_id",
                table: "play_group_decks",
                column: "pilot_id",
                principalTable: "pilots",
                principalColumn: "id");
        }
    }
}
