using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rento.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CoordinatesLongitude",
                table: "Branchs",
                type: "decimal(15,15)",
                precision: 15,
                scale: 15,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,10)",
                oldPrecision: 5,
                oldScale: 10);

            migrationBuilder.AlterColumn<decimal>(
                name: "CoordinatesLatitude",
                table: "Branchs",
                type: "decimal(15,15)",
                precision: 15,
                scale: 15,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,10)",
                oldPrecision: 5,
                oldScale: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CoordinatesLongitude",
                table: "Branchs",
                type: "decimal(5,10)",
                precision: 5,
                scale: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,15)",
                oldPrecision: 15,
                oldScale: 15);

            migrationBuilder.AlterColumn<decimal>(
                name: "CoordinatesLatitude",
                table: "Branchs",
                type: "decimal(5,10)",
                precision: 5,
                scale: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,15)",
                oldPrecision: 15,
                oldScale: 15);
        }
    }
}
