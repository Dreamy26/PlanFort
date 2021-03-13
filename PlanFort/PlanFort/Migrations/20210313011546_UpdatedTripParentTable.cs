using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanFort.Migrations
{
    public partial class UpdatedTripParentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateOfTrip",
                table: "TripParent",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfTrip",
                table: "TripParent");
        }
    }
}
