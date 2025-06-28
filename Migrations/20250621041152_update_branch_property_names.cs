using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rento.Migrations
{
    /// <inheritdoc />
    public partial class update_branch_property_names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Coordinateslongitude",
                table: "Branchs",
                newName: "CoordinatesLongitude");

            migrationBuilder.RenameColumn(
                name: "Coordinateslatitude",
                table: "Branchs",
                newName: "CoordinatesLatitude");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoordinatesLongitude",
                table: "Branchs",
                newName: "Coordinateslongitude");

            migrationBuilder.RenameColumn(
                name: "CoordinatesLatitude",
                table: "Branchs",
                newName: "Coordinateslatitude");
        }
    }
}
