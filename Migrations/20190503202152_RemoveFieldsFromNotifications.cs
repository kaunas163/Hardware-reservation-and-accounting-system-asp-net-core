using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class RemoveFieldsFromNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ReadOn",
                table: "Notifications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Notifications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Notifications",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReadOn",
                table: "Notifications",
                nullable: true);
        }
    }
}
