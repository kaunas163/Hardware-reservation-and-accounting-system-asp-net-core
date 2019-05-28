using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class UpdatePrimaryKeyOfEquipmentsInBundles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentsInBundles",
                table: "EquipmentsInBundles");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentInBundleId",
                table: "EquipmentsInBundles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentsInBundles",
                table: "EquipmentsInBundles",
                columns: new[] { "EquipmentInBundleId", "EquipmentId", "EquipmentBundleId" });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentsInBundles_EquipmentId",
                table: "EquipmentsInBundles",
                column: "EquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipmentsInBundles",
                table: "EquipmentsInBundles");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentsInBundles_EquipmentId",
                table: "EquipmentsInBundles");

            migrationBuilder.DropColumn(
                name: "EquipmentInBundleId",
                table: "EquipmentsInBundles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipmentsInBundles",
                table: "EquipmentsInBundles",
                columns: new[] { "EquipmentId", "EquipmentBundleId" });
        }
    }
}
