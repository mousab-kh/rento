using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rento.Migrations
{
    /// <inheritdoc />
    public partial class DateTime00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Start",
                table: "BranchWorkingHours",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "BranchWorkingHours",
                newName: "EndTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "BranchWorkingHours",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "BranchWorkingHours",
                newName: "End");
        }
    }
}
