using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommanderTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelationshipsToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "play_group_app_users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "play_group_app_users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    app_user_id = table.Column<string>(type: "text", nullable: false),
                    created_by_id = table.Column<string>(type: "text", nullable: false),
                    play_group_id = table.Column<Guid>(type: "uuid", nullable: false),
                    updated_by_id = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Test = table.Column<string>(type: "text", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_play_group_app_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_play_group_app_users_AspNetUsers_app_user_id",
                        column: x => x.app_user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_play_group_app_users_AspNetUsers_created_by_id",
                        column: x => x.created_by_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_play_group_app_users_AspNetUsers_updated_by_id",
                        column: x => x.updated_by_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_play_group_app_users_play_groups_play_group_id",
                        column: x => x.play_group_id,
                        principalTable: "play_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_play_group_app_users_app_user_id",
                table: "play_group_app_users",
                column: "app_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_play_group_app_users_created_by_id",
                table: "play_group_app_users",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "IX_play_group_app_users_play_group_id",
                table: "play_group_app_users",
                column: "play_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_play_group_app_users_updated_by_id",
                table: "play_group_app_users",
                column: "updated_by_id");
        }
    }
}
