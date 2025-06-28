using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rento.Migrations
{
    /// <inheritdoc />
    public partial class Vehicl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleCategories_Branchs_BranchId",
                table: "VehicleCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleCategories",
                table: "VehicleCategories");

            migrationBuilder.RenameTable(
                name: "VehicleCategories",
                newName: "Vehicles");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleCategories_BranchId",
                table: "Vehicles",
                newName: "IX_Vehicles_BranchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Branchs_BranchId",
                table: "Vehicles",
                column: "BranchId",
                principalTable: "Branchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Branchs_BranchId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "VehicleCategories");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_BranchId",
                table: "VehicleCategories",
                newName: "IX_VehicleCategories_BranchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleCategories",
                table: "VehicleCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleCategories_Branchs_BranchId",
                table: "VehicleCategories",
                column: "BranchId",
                principalTable: "Branchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
