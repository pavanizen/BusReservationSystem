using Microsoft.EntityFrameworkCore.Migrations;

namespace Bus.DataLayer.Migrations
{
    public partial class AddedshortdescriptioninLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Locations",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Locations");
        }
    }
}
