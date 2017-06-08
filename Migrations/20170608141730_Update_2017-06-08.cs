using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuantIREnergy2.Migrations
{
    public partial class Update_20170608 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Account");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Transaction",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Institution",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Account",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransactionDate",
                table: "Transaction",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsReceived",
                table: "Invoice",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionDate",
                table: "Transaction");

            migrationBuilder.DropColumn(
                name: "IsReceived",
                table: "Invoice");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Transaction",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Institution",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Account",
                newName: "Name");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Transaction",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Account",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
