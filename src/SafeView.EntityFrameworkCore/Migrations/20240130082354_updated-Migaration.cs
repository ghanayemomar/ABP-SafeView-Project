using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SafeView.Migrations
{
    /// <inheritdoc />
    public partial class updatedMigaration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActuallTotalOrderPrice",
                table: "Orders",
                newName: "PayedTotalOrderPrice");

            migrationBuilder.AddColumn<DateTime>(
                name: "MaintenanceDate",
                table: "Maintenances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Maintenances",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WhatsAppNumber",
                table: "Customers",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaintenanceDate",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Maintenances");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "WhatsAppNumber",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "PayedTotalOrderPrice",
                table: "Orders",
                newName: "ActuallTotalOrderPrice");
        }
    }
}
