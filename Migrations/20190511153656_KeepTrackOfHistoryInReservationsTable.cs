using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class KeepTrackOfHistoryInReservationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OriginalReservationId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_OriginalReservationId",
                table: "Reservations",
                column: "OriginalReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Reservations_OriginalReservationId",
                table: "Reservations",
                column: "OriginalReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Reservations_OriginalReservationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_OriginalReservationId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "OriginalReservationId",
                table: "Reservations");
        }
    }
}
