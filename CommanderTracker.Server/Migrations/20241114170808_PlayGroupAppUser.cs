using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class PlayGroupAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46d28a08-f8ad-4ccb-828a-ed595fdd176d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bb69280-13a5-4279-84fe-1629e747b689");

            migrationBuilder.CreateTable(
                name: "PlayGroupAppUser",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    app_user_id = table.Column<string>(type: "text", nullable: false),
                    play_group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by_id = table.Column<string>(type: "text", nullable: false),
                    updated_by_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayGroupAppUser", x => x.id);
                    table.ForeignKey(
                        name: "FK_PlayGroupAppUser_AspNetUsers_app_user_id",
                        column: x => x.app_user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayGroupAppUser_AspNetUsers_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayGroupAppUser_AspNetUsers_updated_by_id",
                        column: x => x.updated_by_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayGroupAppUser_play_groups_play_group_id",
                        column: x => x.play_group_id,
                        principalTable: "play_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67a14b02-5217-42b4-b80d-7b331678e25a", null, "Admin", "ADMIN" },
                    { "79caad74-d953-48b2-96d4-4bc8a44ceb33", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroupAppUser_app_user_id",
                table: "PlayGroupAppUser",
                column: "app_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroupAppUser_created_by_id",
                table: "PlayGroupAppUser",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroupAppUser_play_group_id",
                table: "PlayGroupAppUser",
                column: "play_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_PlayGroupAppUser_updated_by_id",
                table: "PlayGroupAppUser",
                column: "updated_by_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayGroupAppUser");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67a14b02-5217-42b4-b80d-7b331678e25a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79caad74-d953-48b2-96d4-4bc8a44ceb33");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46d28a08-f8ad-4ccb-828a-ed595fdd176d", null, "User", "USER" },
                    { "5bb69280-13a5-4279-84fe-1629e747b689", null, "Admin", "ADMIN" }
                });
        }
    }
}
