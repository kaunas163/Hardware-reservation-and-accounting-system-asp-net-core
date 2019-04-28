using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class AddRelationToEquipmentsAndBundles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentsInBundles",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(nullable: false),
                    EquipmentBundleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentsInBundles", x => new { x.EquipmentId, x.EquipmentBundleId });
                    table.ForeignKey(
                        name: "FK_EquipmentsInBundles_EquipmentBundles_EquipmentBundleId",
                        column: x => x.EquipmentBundleId,
                        principalTable: "EquipmentBundles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentsInBundles_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentsInBundles_EquipmentBundleId",
                table: "EquipmentsInBundles",
                column: "EquipmentBundleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentsInBundles");
        }
    }
}
