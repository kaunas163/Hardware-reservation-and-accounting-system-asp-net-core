using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class CreateTableNotificationsForMultipleUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationsForUsers",
                columns: table => new
                {
                    NotificationId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    ReadOn = table.Column<DateTime>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationsForUsers", x => new { x.NotificationId, x.UserId });
                    table.ForeignKey(
                        name: "FK_NotificationsForUsers_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificationsForUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsForUsers_UserId",
                table: "NotificationsForUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationsForUsers");
        }
    }
}
