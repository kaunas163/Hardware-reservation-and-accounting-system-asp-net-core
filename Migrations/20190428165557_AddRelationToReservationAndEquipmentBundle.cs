using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class AddRelationToReservationAndEquipmentBundle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentBundleId",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_EquipmentBundleId",
                table: "Reservations",
                column: "EquipmentBundleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_EquipmentBundles_EquipmentBundleId",
                table: "Reservations",
                column: "EquipmentBundleId",
                principalTable: "EquipmentBundles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_EquipmentBundles_EquipmentBundleId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_EquipmentBundleId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EquipmentBundleId",
                table: "Reservations");
        }
    }
}
