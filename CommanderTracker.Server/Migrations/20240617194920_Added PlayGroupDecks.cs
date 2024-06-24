using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedPlayGroupDecks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "583ab045-9e02-45b8-bb9a-035e398b75db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66abeb1a-fc73-4c77-9c57-c1470cb216c2");

            migrationBuilder.CreateTable(
                name: "PlayGroupDecks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeckId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlayGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    PilotId = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by_id = table.Column<string>(type: "text", nullable: false),
                    updated_by_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayGroupDecks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayGroupDecks_AspNetUsers_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayGroupDecks_AspNetUsers_updated_by_id",
                        column: x => x.updated_by_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayGroupDecks_decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "decks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayGroupDecks_pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "pilots",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayGroupDecks_play_groups_PlayGroupId",
                        column: x => x.PlayGroupId,
                        principalTable: "play_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b4391e9-b523-4df0-b504-6aff2248f596", null, "Admin", "ADMIN" },
                    { "656f5762-72c8-47dd-8d90-a30c6528b780", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroupDecks_created_by_id",
                table: "PlayGroupDecks",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroupDecks_DeckId",
                table: "PlayGroupDecks",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroupDecks_PilotId",
                table: "PlayGroupDecks",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroupDecks_PlayGroupId",
                table: "PlayGroupDecks",
                column: "PlayGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroupDecks_updated_by_id",
                table: "PlayGroupDecks",
                column: "updated_by_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayGroupDecks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b4391e9-b523-4df0-b504-6aff2248f596");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "656f5762-72c8-47dd-8d90-a30c6528b780");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "583ab045-9e02-45b8-bb9a-035e398b75db", null, "User", "USER" },
                    { "66abeb1a-fc73-4c77-9c57-c1470cb216c2", null, "Admin", "ADMIN" }
                });
        }
    }
}
