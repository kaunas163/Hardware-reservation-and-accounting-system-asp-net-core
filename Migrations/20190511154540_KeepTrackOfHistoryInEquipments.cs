using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class KeepTrackOfHistoryInEquipments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OriginalEquipmentId",
                table: "Equipments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_OriginalEquipmentId",
                table: "Equipments",
                column: "OriginalEquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Equipments_OriginalEquipmentId",
                table: "Equipments",
                column: "OriginalEquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Equipments_OriginalEquipmentId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_OriginalEquipmentId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "OriginalEquipmentId",
                table: "Equipments");
        }
    }
}
