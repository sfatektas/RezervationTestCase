using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RezervationTestCase.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class numberofvisitorAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EntiryDate",
                table: "Bookings",
                newName: "EntryDate");

            migrationBuilder.AlterColumn<string>(
                name: "TelNo",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfVisitor",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "NumberOfVisitor",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "EntryDate",
                table: "Bookings",
                newName: "EntiryDate");

            migrationBuilder.AlterColumn<string>(
                name: "TelNo",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
