using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class KeepTrackOfHistoryInEquipmentBundles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OriginalEquipmentBundleId",
                table: "EquipmentBundles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentBundles_OriginalEquipmentBundleId",
                table: "EquipmentBundles",
                column: "OriginalEquipmentBundleId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentBundles_EquipmentBundles_OriginalEquipmentBundleId",
                table: "EquipmentBundles",
                column: "OriginalEquipmentBundleId",
                principalTable: "EquipmentBundles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentBundles_EquipmentBundles_OriginalEquipmentBundleId",
                table: "EquipmentBundles");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentBundles_OriginalEquipmentBundleId",
                table: "EquipmentBundles");

            migrationBuilder.DropColumn(
                name: "OriginalEquipmentBundleId",
                table: "EquipmentBundles");
        }
    }
}
