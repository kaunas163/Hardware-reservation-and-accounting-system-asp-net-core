using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class AddPicturesToEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Pictures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_EquipmentId",
                table: "Pictures",
                column: "EquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Equipments_EquipmentId",
                table: "Pictures",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Equipments_EquipmentId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_EquipmentId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Pictures");
        }
    }
}
