using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rento.Migrations
{
    /// <inheritdoc />
    public partial class rental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentalRateSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalName = table.Column<int>(type: "int", nullable: false),
                    DayRentFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    DayRentTo = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalRateSchemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentalRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    VehicleCategorieId = table.Column<int>(type: "int", nullable: false),
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RentalRateSchemasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalRates_RentalRateSchemas_RentalRateSchemasId",
                        column: x => x.RentalRateSchemasId,
                        principalTable: "RentalRateSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalRates_RentalRateSchemasId",
                table: "RentalRates",
                column: "RentalRateSchemasId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalRates");

            migrationBuilder.DropTable(
                name: "RentalRateSchemas");
        }
    }
}
