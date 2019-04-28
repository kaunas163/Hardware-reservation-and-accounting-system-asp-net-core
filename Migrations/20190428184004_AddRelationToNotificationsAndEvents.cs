﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class AddRelationToNotificationsAndEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Notifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_EventId",
                table: "Notifications",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Events_EventId",
                table: "Notifications",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Events_EventId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_EventId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Notifications");
        }
    }
}
