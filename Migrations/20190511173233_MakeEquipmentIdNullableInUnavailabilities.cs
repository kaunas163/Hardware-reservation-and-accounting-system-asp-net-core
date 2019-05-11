using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class MakeEquipmentIdNullableInUnavailabilities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unavailabilities_Equipments_EquipmentId",
                table: "Unavailabilities");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                table: "Unavailabilities",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Unavailabilities_Equipments_EquipmentId",
                table: "Unavailabilities",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unavailabilities_Equipments_EquipmentId",
                table: "Unavailabilities");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                table: "Unavailabilities",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Unavailabilities_Equipments_EquipmentId",
                table: "Unavailabilities",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
