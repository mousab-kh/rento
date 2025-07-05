using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rento.Migrations
{
    /// <inheritdoc />
    public partial class NuGet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleModelYear",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "VehicleModelYear",
                table: "VehicleModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleModelYear",
                table: "VehicleModels");

            migrationBuilder.AddColumn<int>(
                name: "VehicleModelYear",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
