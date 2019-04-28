using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class AddRelationToEquipmentsAndTheirTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentTypeId",
                table: "Equipments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_EquipmentTypeId",
                table: "Equipments",
                column: "EquipmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_EquipmentTypes_EquipmentTypeId",
                table: "Equipments",
                column: "EquipmentTypeId",
                principalTable: "EquipmentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_EquipmentTypes_EquipmentTypeId",
                table: "Equipments");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_EquipmentTypeId",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "EquipmentTypeId",
                table: "Equipments");
        }
    }
}
