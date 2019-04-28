using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class AddRelationToNotificationsAndBundles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentBundleId",
                table: "Notifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_EquipmentBundleId",
                table: "Notifications",
                column: "EquipmentBundleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_EquipmentBundles_EquipmentBundleId",
                table: "Notifications",
                column: "EquipmentBundleId",
                principalTable: "EquipmentBundles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_EquipmentBundles_EquipmentBundleId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_EquipmentBundleId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "EquipmentBundleId",
                table: "Notifications");
        }
    }
}
