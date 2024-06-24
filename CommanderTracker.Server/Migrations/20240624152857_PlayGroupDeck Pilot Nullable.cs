using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class PlayGroupDeckPilotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayGroupDecks_pilots_PilotId",
                table: "PlayGroupDecks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e1f61c9-068d-45d0-a595-22966387f096");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc119ebe-682f-41f1-8589-8edf74fda0e0");

            migrationBuilder.AlterColumn<Guid>(
                name: "PilotId",
                table: "PlayGroupDecks",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a544bd44-23a1-492c-960f-e59efd6392f1", null, "Admin", "ADMIN" },
                    { "e4dbe3b5-52a0-4586-bfcb-aee760c052cb", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayGroupDecks_pilots_PilotId",
                table: "PlayGroupDecks",
                column: "PilotId",
                principalTable: "pilots",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayGroupDecks_pilots_PilotId",
                table: "PlayGroupDecks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a544bd44-23a1-492c-960f-e59efd6392f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4dbe3b5-52a0-4586-bfcb-aee760c052cb");

            migrationBuilder.AlterColumn<Guid>(
                name: "PilotId",
                table: "PlayGroupDecks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e1f61c9-068d-45d0-a595-22966387f096", null, "Admin", "ADMIN" },
                    { "fc119ebe-682f-41f1-8589-8edf74fda0e0", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PlayGroupDecks_pilots_PilotId",
                table: "PlayGroupDecks",
                column: "PilotId",
                principalTable: "pilots",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
