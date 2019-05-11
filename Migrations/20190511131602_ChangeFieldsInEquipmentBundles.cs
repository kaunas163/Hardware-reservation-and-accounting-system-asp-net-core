using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class ChangeFieldsInEquipmentBundles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "EquipmentBundles");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "EquipmentBundles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "EquipmentBundles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "EquipmentBundles");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "EquipmentBundles");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "EquipmentBundles",
                nullable: false,
                defaultValue: false);
        }
    }
}
