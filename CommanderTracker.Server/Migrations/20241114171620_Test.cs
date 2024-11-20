using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67a14b02-5217-42b4-b80d-7b331678e25a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79caad74-d953-48b2-96d4-4bc8a44ceb33");

            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "PlayGroupAppUser",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "PlayGroupAppUser");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67a14b02-5217-42b4-b80d-7b331678e25a", null, "Admin", "ADMIN" },
                    { "79caad74-d953-48b2-96d4-4bc8a44ceb33", null, "User", "USER" }
                });
        }
    }
}
