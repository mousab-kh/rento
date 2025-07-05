using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rento.Migrations
{
    /// <inheritdoc />
    public partial class All : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DropOffBranchId",
                table: "Bookings",
                column: "DropOffBranchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RentalRateId",
                table: "Bookings",
                column: "RentalRateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VehicleModelId",
                table: "Bookings",
                column: "VehicleModelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Branchs_DropOffBranchId",
                table: "Bookings",
                column: "DropOffBranchId",
                principalTable: "Branchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_RentalRates_RentalRateId",
                table: "Bookings",
                column: "RentalRateId",
                principalTable: "RentalRates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_VehicleModels_VehicleModelId",
                table: "Bookings",
                column: "VehicleModelId",
                principalTable: "VehicleModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Branchs_DropOffBranchId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_RentalRates_RentalRateId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_VehicleModels_VehicleModelId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_DropOffBranchId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RentalRateId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_VehicleModelId",
                table: "Bookings");
        }
    }
}
