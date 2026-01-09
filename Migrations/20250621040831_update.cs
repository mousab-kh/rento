using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rento.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchWorkingHours_Branchs_BranchId",
                table: "BranchWorkingHours");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "BranchWorkingHours");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "BranchWorkingHours");

            migrationBuilder.RenameColumn(
                name: "Validworkinghour",
                table: "BranchWorkingHours",
                newName: "ValidWorkinghour");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidWorkinghour",
                table: "BranchWorkingHours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "BranchWorkingHours",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "BranchWorkingHours",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "BranchWorkingHours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "BranchWorkingHours",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Branchs",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchWorkingHours_Branchs_BranchId",
                table: "BranchWorkingHours",
                column: "BranchId",
                principalTable: "Branchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchWorkingHours_Branchs_BranchId",
                table: "BranchWorkingHours");

            migrationBuilder.DropColumn(
                name: "End",
                table: "BranchWorkingHours");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "BranchWorkingHours");

            migrationBuilder.RenameColumn(
                name: "ValidWorkinghour",
                table: "BranchWorkingHours",
                newName: "Validworkinghour");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Validworkinghour",
                table: "BranchWorkingHours",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "BranchWorkingHours",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "BranchId",
                table: "BranchWorkingHours",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "BranchWorkingHours",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "BranchWorkingHours",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Branchs",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchWorkingHours_Branchs_BranchId",
                table: "BranchWorkingHours",
                column: "BranchId",
                principalTable: "Branchs",
                principalColumn: "Id");
        }
    }
}
