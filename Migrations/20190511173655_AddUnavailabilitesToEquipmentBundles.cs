using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class AddUnavailabilitesToEquipmentBundles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentBundleId",
                table: "Unavailabilities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Unavailabilities_EquipmentBundleId",
                table: "Unavailabilities",
                column: "EquipmentBundleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Unavailabilities_EquipmentBundles_EquipmentBundleId",
                table: "Unavailabilities",
                column: "EquipmentBundleId",
                principalTable: "EquipmentBundles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unavailabilities_EquipmentBundles_EquipmentBundleId",
                table: "Unavailabilities");

            migrationBuilder.DropIndex(
                name: "IX_Unavailabilities_EquipmentBundleId",
                table: "Unavailabilities");

            migrationBuilder.DropColumn(
                name: "EquipmentBundleId",
                table: "Unavailabilities");
        }
    }
}
