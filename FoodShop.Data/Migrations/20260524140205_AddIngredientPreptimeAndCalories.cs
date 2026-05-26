using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIngredientPreptimeAndCalories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Calories",
                table: "Foods",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Foods",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PrepTime",
                table: "Foods",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodID",
                keyValue: 1,
                columns: new[] { "Calories", "Ingredients", "PrepTime" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodID",
                keyValue: 2,
                columns: new[] { "Calories", "Ingredients", "PrepTime" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodID",
                keyValue: 3,
                columns: new[] { "Calories", "Ingredients", "PrepTime" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodID",
                keyValue: 4,
                columns: new[] { "Calories", "Ingredients", "PrepTime" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodID",
                keyValue: 5,
                columns: new[] { "Calories", "Ingredients", "PrepTime" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodID",
                keyValue: 6,
                columns: new[] { "Calories", "Ingredients", "PrepTime" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 6, 2, 4, 868, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 6, 2, 4, 868, DateTimeKind.Local).AddTicks(2095));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 5, 24, 6, 2, 4, 868, DateTimeKind.Local).AddTicks(2099));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calories",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "PrepTime",
                table: "Foods");

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
    }
}
