using Microsoft.EntityFrameworkCore.Migrations;

namespace Bus.DataLayer.Migrations
{
    public partial class AddedRouteidinLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Trips_TripId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_TripId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Locations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RouteId",
                table: "Locations",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Routes_RouteId",
                table: "Locations",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Routes_RouteId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_RouteId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_TripId",
                table: "Locations",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Trips_TripId",
                table: "Locations",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "TripID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
