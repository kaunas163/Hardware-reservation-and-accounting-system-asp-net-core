using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class AddDateTimeFieldsToEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Equipments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Equipments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Equipments");
        }
    }
}
