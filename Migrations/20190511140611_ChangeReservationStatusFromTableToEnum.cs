using Microsoft.EntityFrameworkCore.Migrations;

namespace HardwareReservationAndAccountingSystem.Migrations
{
    public partial class ChangeReservationStatusFromTableToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationStatuses_ReservationStatusId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "ReservationStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationStatusId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationStatusId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Reservations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservations");

            migrationBuilder.AddColumn<byte>(
                name: "ReservationStatusId",
                table: "Reservations",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "ReservationStatuses",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationStatusId",
                table: "Reservations",
                column: "ReservationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationStatuses_ReservationStatusId",
                table: "Reservations",
                column: "ReservationStatusId",
                principalTable: "ReservationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
