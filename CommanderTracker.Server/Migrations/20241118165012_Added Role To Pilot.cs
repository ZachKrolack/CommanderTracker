using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedRoleToPilot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "pilots");

            migrationBuilder.AddColumn<int>(
                name: "role",
                table: "pilots",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "pilots");

            migrationBuilder.AddColumn<string>(
                name: "test",
                table: "pilots",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
