using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rento.Migrations
{
    /// <inheritdoc />
    public partial class Updated_branch_intervals_type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidWorkinghour",
                table: "BranchWorkingHours");

            migrationBuilder.AddColumn<string>(
                name: "Intervals",
                table: "BranchWorkingHours",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Intervals",
                table: "BranchWorkingHours");

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidWorkinghour",
                table: "BranchWorkingHours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
