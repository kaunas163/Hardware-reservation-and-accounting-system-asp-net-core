using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class AddUnavailabilitiesToEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Unavailabilities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Unavailabilities_EquipmentId",
                table: "Unavailabilities",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Unavailabilities_Equipments_EquipmentId",
                table: "Unavailabilities",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unavailabilities_Equipments_EquipmentId",
                table: "Unavailabilities");

            migrationBuilder.DropIndex(
                name: "IX_Unavailabilities_EquipmentId",
                table: "Unavailabilities");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Unavailabilities");
        }
    }
}
