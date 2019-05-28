using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class UpdateFieldNameOfEquipmentsInBundles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EquipmentInBundleId",
                table: "EquipmentsInBundles",
                newName: "EquipmentsInBundlesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EquipmentsInBundlesId",
                table: "EquipmentsInBundles",
                newName: "EquipmentInBundleId");
        }
    }
}
