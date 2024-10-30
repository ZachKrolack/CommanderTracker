using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedPlayGroupDecksRelationToDeck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58a3b9e9-a5c8-4107-8176-dd95d44a55c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe31d21b-b170-41f9-91cb-9ff22e9c84be");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "252c9bf9-b5c0-4501-8014-b3728e46370c", null, "Admin", "ADMIN" },
                    { "e4824fac-6415-47e0-bc4f-dd37f6f2402d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "252c9bf9-b5c0-4501-8014-b3728e46370c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4824fac-6415-47e0-bc4f-dd37f6f2402d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58a3b9e9-a5c8-4107-8176-dd95d44a55c9", null, "Admin", "ADMIN" },
                    { "fe31d21b-b170-41f9-91cb-9ff22e9c84be", null, "User", "USER" }
                });
        }
    }
}
