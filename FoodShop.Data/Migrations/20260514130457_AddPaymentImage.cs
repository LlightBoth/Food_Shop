using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentImage",
                table: "Invoices",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 14, 5, 4, 56, 671, DateTimeKind.Local).AddTicks(7804));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 14, 5, 4, 56, 671, DateTimeKind.Local).AddTicks(7809));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 14, 5, 4, 56, 671, DateTimeKind.Local).AddTicks(7813));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentImage",
                table: "Invoices");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 14, 4, 16, 0, 6, DateTimeKind.Local).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 14, 4, 16, 0, 6, DateTimeKind.Local).AddTicks(6355));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 14, 4, 16, 0, 6, DateTimeKind.Local).AddTicks(6359));
        }
    }
}
