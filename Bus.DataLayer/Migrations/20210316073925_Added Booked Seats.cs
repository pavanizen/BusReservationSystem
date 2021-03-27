using Microsoft.EntityFrameworkCore.Migrations;

namespace Bus.DataLayer.Migrations
{
    public partial class AddedBookedSeats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AvailableSeats",
                table: "Trips",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BookedSeats",
                columns: table => new
                {
                    SeatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    TripsID = table.Column<int>(nullable: false),
                    A1 = table.Column<decimal>(nullable: false),
                    A2 = table.Column<decimal>(nullable: false),
                    A3 = table.Column<decimal>(nullable: false),
                    A4 = table.Column<decimal>(nullable: false),
                    A5 = table.Column<decimal>(nullable: false),
                    A6 = table.Column<decimal>(nullable: false),
                    A7 = table.Column<decimal>(nullable: false),
                    A8 = table.Column<decimal>(nullable: false),
                    A9 = table.Column<decimal>(nullable: false),
                    A10 = table.Column<decimal>(nullable: false),
                    B1 = table.Column<decimal>(nullable: false),
                    B2 = table.Column<decimal>(nullable: false),
                    B3 = table.Column<decimal>(nullable: false),
                    B4 = table.Column<decimal>(nullable: false),
                    B5 = table.Column<decimal>(nullable: false),
                    B6 = table.Column<decimal>(nullable: false),
                    B7 = table.Column<decimal>(nullable: false),
                    B8 = table.Column<decimal>(nullable: false),
                    B9 = table.Column<decimal>(nullable: false),
                    B10 = table.Column<decimal>(nullable: false),
                    C1 = table.Column<decimal>(nullable: false),
                    C2 = table.Column<decimal>(nullable: false),
                    C3 = table.Column<decimal>(nullable: false),
                    C4 = table.Column<decimal>(nullable: false),
                    C5 = table.Column<decimal>(nullable: false),
                    C6 = table.Column<decimal>(nullable: false),
                    C7 = table.Column<decimal>(nullable: false),
                    C8 = table.Column<decimal>(nullable: false),
                    C9 = table.Column<decimal>(nullable: false),
                    C10 = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookedSeats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_BookedSeats_Trips_TripsID",
                        column: x => x.TripsID,
                        principalTable: "Trips",
                        principalColumn: "TripID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookedSeats_TripsID",
                table: "BookedSeats",
                column: "TripsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookedSeats");

            migrationBuilder.AlterColumn<string>(
                name: "AvailableSeats",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
