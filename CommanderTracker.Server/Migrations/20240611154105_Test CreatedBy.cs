using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class TestCreatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35ff14de-a624-4956-9650-6094e5bd7b9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fde7595b-51db-47f2-897c-325da905aaac");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "decks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d83aac67-5267-4847-9bf1-2f25767daa40", null, "User", "USER" },
                    { "ee1ef752-e757-4da4-831e-158bdf82d434", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_decks_CreatedById",
                table: "decks",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_decks_AspNetUsers_CreatedById",
                table: "decks",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_decks_AspNetUsers_CreatedById",
                table: "decks");

            migrationBuilder.DropIndex(
                name: "IX_decks_CreatedById",
                table: "decks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d83aac67-5267-4847-9bf1-2f25767daa40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee1ef752-e757-4da4-831e-158bdf82d434");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "decks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35ff14de-a624-4956-9650-6094e5bd7b9b", null, "User", "USER" },
                    { "fde7595b-51db-47f2-897c-325da905aaac", null, "Admin", "ADMIN" }
                });
        }
    }
}
