using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class AddRelationToNotificationsAndEquipments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Notifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_EquipmentId",
                table: "Notifications",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Equipments_EquipmentId",
                table: "Notifications",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Equipments_EquipmentId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_EquipmentId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Notifications");
        }
    }
}
