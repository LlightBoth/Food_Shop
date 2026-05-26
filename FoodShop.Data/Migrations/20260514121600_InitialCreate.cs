using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FoodCategories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descriptions = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCategories", x => x.CategoryID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JobName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    PageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PageName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descriptions = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.PageID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FoodName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FoodCategoryID = table.Column<int>(type: "int", nullable: false),
                    FoodImageID = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodID);
                    table.ForeignKey(
                        name: "FK_Foods_FoodCategories_FoodCategoryID",
                        column: x => x.FoodCategoryID,
                        principalTable: "FoodCategories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmployeeName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InvoiceDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SellerID = table.Column<int>(type: "int", nullable: false),
                    DeliveryID = table.Column<int>(type: "int", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    TotalFee = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Employees_DeliveryID",
                        column: x => x.DeliveryID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Employees_SellerID",
                        column: x => x.SellerID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descriptions = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ByEmployeeID = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                    table.ForeignKey(
                        name: "FK_Roles_Employees_ByEmployeeID",
                        column: x => x.ByEmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    FoodID = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => new { x.InvoiceID, x.FoodID });
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Foods_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Foods",
                        principalColumn: "FoodID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Role_Permissions",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    PageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Permissions", x => new { x.RoleID, x.PageID });
                    table.ForeignKey(
                        name: "FK_Role_Permissions_Pages_PageID",
                        column: x => x.PageID,
                        principalTable: "Pages",
                        principalColumn: "PageID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_Permissions_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "FoodCategories",
                columns: new[] { "CategoryID", "CategoryName", "CreatedAt", "Descriptions" },
                values: new object[,]
                {
                    { 1, "Fast Food", new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burgers, pizza, fried chicken, and snacks" },
                    { 2, "Drink", new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Drinks like coffee, tea, and soft drinks" },
                    { 3, "Desserts", new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweet foods like cakes and ice cream" },
                    { 4, "Snacks", new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Light snacks and side dishes" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobID", "CreatedAt", "Description", "JobName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manage the whole system", "Admin" },
                    { 2, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handle customer payments and invoices", "Cashier" },
                    { 3, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assist customers and handle complaints", "Customer Support" },
                    { 4, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assist customers and Delivered ordered", "Delivery" }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "PageID", "CreatedAt", "Descriptions", "PageName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 17, 4, 20, 13, 0, DateTimeKind.Unspecified), "System dashboard", "Dashboard" },
                    { 2, new DateTime(2026, 3, 17, 4, 20, 18, 0, DateTimeKind.Unspecified), "Manage food categories", "Category" },
                    { 3, new DateTime(2026, 3, 17, 4, 20, 22, 0, DateTimeKind.Unspecified), "Manage food products", "Food" },
                    { 4, new DateTime(2026, 4, 1, 8, 6, 58, 0, DateTimeKind.Unspecified), "Manage customers", "Customer" },
                    { 5, new DateTime(2026, 4, 1, 8, 7, 5, 0, DateTimeKind.Unspecified), "Manage employees", "Employee" },
                    { 6, new DateTime(2026, 4, 1, 8, 7, 10, 0, DateTimeKind.Unspecified), "Manage jobs", "Job" },
                    { 7, new DateTime(2026, 4, 1, 8, 7, 18, 0, DateTimeKind.Unspecified), "Manage roles and permissions", "Role" },
                    { 8, new DateTime(2026, 4, 1, 8, 7, 22, 0, DateTimeKind.Unspecified), "Manage application pages", "Page" },
                    { 9, new DateTime(2026, 4, 1, 8, 7, 22, 0, DateTimeKind.Unspecified), "Manage delivered pages", "Delivery" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "ByEmployeeID", "CreatedAt", "Descriptions", "RoleName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 5, 14, 4, 16, 0, 6, DateTimeKind.Local).AddTicks(6350), "System administrator", "Admin", null },
                    { 2, null, new DateTime(2026, 5, 14, 4, 16, 0, 6, DateTimeKind.Local).AddTicks(6355), "Manage orders and employees", "Manager", null },
                    { 3, null, new DateTime(2026, 5, 14, 4, 16, 0, 6, DateTimeKind.Local).AddTicks(6359), "Limited employee access", "Staff", null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "CreatedAt", "DateBirth", "Email", "EmployeeName", "JobId", "Password", "Phone", "Remark", "RoleId" },
                values: new object[,]
                {
                    { 1, "Phnom Penh", new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1998, 1, 1), "finn@foodshop.com", "F1nnTh3Human", 1, "Finn123", "012345678", "Main administrator account", 1 },
                    { 2, "Kandal", new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1997, 5, 12), "jake@foodshop.com", "Jake", 2, "Jake123", "098765432", "Store manager", 2 },
                    { 3, "Takeo", new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1999, 8, 20), "marceline@foodshop.com", "Marceline", 3, "Marceline123", "097111222", "Morning seller", 3 },
                    { 4, "Battambang", new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(1996, 3, 15), "iceking@foodshop.com", "IceKing", 3, "Iceking123", "096333444", "Afternoon seller", 3 },
                    { 5, "Siem Reap", new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2001, 11, 11), "gumball@foodshop.com", "Gumball", 2, "Gumball123", "088555666", "Night seller", 3 },
                    { 6, "Siem Reap", new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateOnly(2001, 11, 11), "darwin@foodshop.com", "Gumball", 4, "Darwin123", "086555666", "Night seller", 3 }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodID", "CreatedAt", "Description", "FoodCategoryID", "FoodImageID", "FoodName", "Qty", "SellPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grilled chicken burger with fresh vegetables", 1, "burger.jpg", "Chicken Burger", 50, 3.50m },
                    { 2, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Classic cheese pizza with mozzarella", 1, "pizza.jpg", "Cheese Pizza", 40, 5.00m },
                    { 3, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crispy fried chicken", 1, "grilled chicken.jpg", "Chicken", 60, 4.00m },
                    { 4, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cold brewed iced coffee", 2, "iced_coffee.jpg", "Iced Coffee", 100, 1.50m },
                    { 5, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweet milk tea with pearls", 2, "milk_tea.jpg", "Milk Tea", 80, 2.00m },
                    { 6, new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Golden crispy french fries", 1, "fries.jpg", "French Fries", 70, 2.50m }
                });

            migrationBuilder.InsertData(
                table: "Role_Permissions",
                columns: new[] { "PageID", "RoleID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 1, 3 },
                    { 3, 3 },
                    { 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobId",
                table: "Employees",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodCategoryID",
                table: "Foods",
                column: "FoodCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_FoodID",
                table: "InvoiceDetails",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerID",
                table: "Invoices",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_DeliveryID",
                table: "Invoices",
                column: "DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SellerID",
                table: "Invoices",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permissions_PageID",
                table: "Role_Permissions",
                column: "PageID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ByEmployeeID",
                table: "Roles",
                column: "ByEmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Jobs_JobId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Role_Permissions");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "FoodCategories");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
