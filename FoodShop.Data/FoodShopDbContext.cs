using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;



namespace FoodShop.Data
{
    public class FoodShopDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Foods> Foods { get; set; }
        public DbSet<Food_Categories> FoodCategories { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<Invoice_Details> InvoiceDetails { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Pages> Pages { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Role_Permissions> Role_Permissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = "server=localhost;port=3500;database=FoodShopDB;user=root;password=123456";
            optionsBuilder.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ------------------ Primary Keys ------------------ //
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeID);
            modelBuilder.Entity<Employee>().Property(e => e.EmployeeID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerID);
            modelBuilder.Entity<Customer>().Property(c => c.CustomerID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Foods>().HasKey(f => f.FoodID);
            modelBuilder.Entity<Foods>().Property(f => f.FoodID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Food_Categories>().HasKey(fc => fc.CategoryID);
            modelBuilder.Entity<Food_Categories>().Property(fc => fc.CategoryID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Invoices>().HasKey(i => i.InvoiceID);
            modelBuilder.Entity<Invoices>().Property(i => i.InvoiceID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Jobs>().HasKey(j => j.JobID);
            modelBuilder.Entity<Jobs>().Property(j => j.JobID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Pages>().HasKey(p => p.PageID);
            modelBuilder.Entity<Pages>().Property(p => p.PageID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Roles>().HasKey(r => r.RoleID);
            modelBuilder.Entity<Roles>().Property(r => r.RoleID).ValueGeneratedOnAdd();

            // ------------------ Point Reference ------------------ //
            //modelBuilder.Entity<Invoice_Details>()
            //    .ToTable("invoice_details"); // exact table name in MySQL

            // ------------------ Composite Keys ------------------ //
            modelBuilder.Entity<Invoice_Details>().HasKey(ivd => new { ivd.InvoiceID, ivd.FoodID });
            modelBuilder.Entity<Role_Permissions>().HasKey(rp => new { rp.RoleID, rp.PageID });

            // ------------------ Relationships ------------------ //

            // Invoice -> InvoiceDetails (one-to-many)
            modelBuilder.Entity<Invoices>()
                .HasMany(i => i.InvoiceDetails)
                .WithOne(ivd => ivd.Invoices)
                .HasForeignKey(ivd => ivd.InvoiceID)
                .OnDelete(DeleteBehavior.Cascade);

            // Food -> InvoiceDetails (one-to-many)
            modelBuilder.Entity<Foods>()
                .HasMany(f => f.Invoice_Details)
                .WithOne(ivd => ivd.Foods)
                .HasForeignKey(ivd => ivd.FoodID)
                .OnDelete(DeleteBehavior.Cascade);

            // Role -> RolePermissions (one-to-many)
            modelBuilder.Entity<Roles>()
                .HasMany(r => r.RolePermissions)
                .WithOne(rp => rp.Roles)
                .HasForeignKey(rp => rp.RoleID)
                .OnDelete(DeleteBehavior.Cascade);

            // Page -> RolePermissions (one-to-many)
            modelBuilder.Entity<Pages>()
                .HasMany(p => p.RolePermissions)
                .WithOne(rp => rp.Pages)
                .HasForeignKey(rp => rp.PageID)
                .OnDelete(DeleteBehavior.Cascade);

            // FoodCategory -> Foods (one-to-many)
            modelBuilder.Entity<Food_Categories>()
                .HasMany(fc => fc.Foods)
                .WithOne(f => f.FoodCategory)
                .HasForeignKey(f => f.FoodCategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee (Seller) -> Invoices (one-to-many)
            modelBuilder.Entity<Invoices>()
                .HasOne(i => i.Seller)
                .WithMany(e => e.Invoices)
                .HasForeignKey(i => i.SellerID)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee (Delivery) -> Invoices (one-to-many)
            modelBuilder.Entity<Invoices>()
                .HasOne(i => i.Delivery)
                .WithMany(e => e.DeliveredInvoices)
                .HasForeignKey(i => i.DeliveryID)
                .OnDelete(DeleteBehavior.Restrict);

            // Customer (Buyer) -> Invoices (one-to-many)
            modelBuilder.Entity<Invoices>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            // Roles → ByEmployee 
            modelBuilder.Entity<Roles>()
                .HasOne(r => r.ByEmployee)
                .WithMany() // optional, no navigation in Employee
                .HasForeignKey(r => r.ByEmployeeID)
                .OnDelete(DeleteBehavior.Restrict);


            // ------------------ Add Data Components ------------------ //

            // ------------------ Seed Roles ------------------ //
            modelBuilder.Entity<Roles>().HasData(
                new Roles
                {
                    RoleID = 1,
                    RoleName = "Admin",
                    Descriptions = "System administrator",
                    CreatedAt = DateTime.Now
                },
                new Roles
                {
                    RoleID = 2,
                    RoleName = "Manager",
                    Descriptions = "Manage orders and employees",
                    CreatedAt = DateTime.Now
                },
                new Roles
                {
                    RoleID = 3,
                    RoleName = "Staff",
                    Descriptions = "Limited employee access",
                    CreatedAt = DateTime.Now
                }
            );

            // ------------------ Seed Jobs ------------------ //
            modelBuilder.Entity<Jobs>().HasData(
                new Jobs
                {
                    JobID = 1,
                    JobName = "Admin",
                    Description = "Manage the whole system",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Jobs
                {
                    JobID = 2,
                    JobName = "Cashier",
                    Description = "Handle customer payments and invoices",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Jobs
                {
                    JobID = 3,
                    JobName = "Customer Support",
                    Description = "Assist customers and handle complaints",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Jobs
                {
                    JobID = 4,
                    JobName = "Delivery",
                    Description = "Assist customers and Delivered ordered",
                    CreatedAt = new DateTime(2026, 5, 7)
                }
            );

            // ------------------ Seed Pages ------------------ //
            modelBuilder.Entity<Pages>().HasData(
                new Pages
                {
                    PageID = 1,
                    PageName = "Dashboard",
                    Descriptions = "System dashboard",
                    CreatedAt = new DateTime(2026, 3, 17, 4, 20, 13)
                },
                new Pages
                {
                    PageID = 2,
                    PageName = "Category",
                    Descriptions = "Manage food categories",
                    CreatedAt = new DateTime(2026, 3, 17, 4, 20, 18)
                },
                new Pages
                {
                    PageID = 3,
                    PageName = "Food",
                    Descriptions = "Manage food products",
                    CreatedAt = new DateTime(2026, 3, 17, 4, 20, 22)
                },
                new Pages
                {
                    PageID = 4,
                    PageName = "Customer",
                    Descriptions = "Manage customers",
                    CreatedAt = new DateTime(2026, 4, 1, 8, 6, 58)
                },
                new Pages
                {
                    PageID = 5,
                    PageName = "Employee",
                    Descriptions = "Manage employees",
                    CreatedAt = new DateTime(2026, 4, 1, 8, 7, 5)
                },
                new Pages
                {
                    PageID = 6,
                    PageName = "Job",
                    Descriptions = "Manage jobs",
                    CreatedAt = new DateTime(2026, 4, 1, 8, 7, 10)
                },
                new Pages
                {
                    PageID = 7,
                    PageName = "Role",
                    Descriptions = "Manage roles and permissions",
                    CreatedAt = new DateTime(2026, 4, 1, 8, 7, 18)
                },
                new Pages
                {
                    PageID = 8,
                    PageName = "Page",
                    Descriptions = "Manage application pages",
                    CreatedAt = new DateTime(2026, 4, 1, 8, 7, 22)
                },
                new Pages
                {
                    PageID = 9,
                    PageName = "Delivery",
                    Descriptions = "Manage delivered pages",
                    CreatedAt = new DateTime(2026, 4, 1, 8, 7, 22)
                }
            );

            // ------------------ Seed Role Permissions ------------------ //
            modelBuilder.Entity<Role_Permissions>().HasData(
                // Dashboard
                new Role_Permissions { RoleID = 1, PageID = 1 },
                new Role_Permissions { RoleID = 2, PageID = 1 },
                new Role_Permissions { RoleID = 3, PageID = 1 },

                // Category
                new Role_Permissions { RoleID = 1, PageID = 2 },
                new Role_Permissions { RoleID = 2, PageID = 2 },

                // Food
                new Role_Permissions { RoleID = 1, PageID = 3 },
                new Role_Permissions { RoleID = 2, PageID = 3 },
                new Role_Permissions { RoleID = 3, PageID = 3 },

                // Customer
                new Role_Permissions { RoleID = 1, PageID = 4 },
                new Role_Permissions { RoleID = 2, PageID = 4 },
                new Role_Permissions { RoleID = 3, PageID = 4 },

                // Employee
                new Role_Permissions { RoleID = 1, PageID = 5 },
                new Role_Permissions { RoleID = 2, PageID = 5 },

                // Job
                new Role_Permissions { RoleID = 1, PageID = 6 },
                new Role_Permissions { RoleID = 2, PageID = 6 },

                // Role
                new Role_Permissions { RoleID = 1, PageID = 7 },

                // Page
                new Role_Permissions { RoleID = 1, PageID = 8 }
            );

            // ------------------ Seed Employees ------------------ //
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeID = 1,
                    EmployeeName = "F1nnTh3Human",
                    DateBirth = new DateOnly(1998, 1, 1),
                    Address = "Phnom Penh",
                    Phone = "012345678",
                    JobId = 1,
                    RoleId = 1, 
                    Remark = "Main administrator account",
                    Email = "finn@foodshop.com",
                    Password = "Finn123",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Employee
                {
                    EmployeeID = 2,
                    EmployeeName = "Jake",
                    DateBirth = new DateOnly(1997, 5, 12),
                    Address = "Kandal",
                    Phone = "098765432",
                    JobId = 2,
                    RoleId = 2, 
                    Remark = "Store manager",
                    Email = "jake@foodshop.com",
                    Password = "Jake123",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Employee
                {
                    EmployeeID = 3,
                    EmployeeName = "Marceline",
                    DateBirth = new DateOnly(1999, 8, 20),
                    Address = "Takeo",
                    Phone = "097111222",
                    JobId = 3,
                    RoleId = 3,
                    Remark = "Morning seller",
                    Email = "marceline@foodshop.com",
                    Password = "Marceline123",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Employee
                {
                    EmployeeID = 4,
                    EmployeeName = "IceKing",
                    DateBirth = new DateOnly(1996, 3, 15),
                    Address = "Battambang",
                    Phone = "096333444",
                    JobId = 3,
                    RoleId = 3, 
                    Remark = "Afternoon seller",
                    Email = "iceking@foodshop.com",
                    Password = "Iceking123",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Employee
                {
                    EmployeeID = 5,
                    EmployeeName = "Gumball",
                    DateBirth = new DateOnly(2001, 11, 11),
                    Address = "Siem Reap",
                    Phone = "088555666",
                    JobId = 2,
                    RoleId = 3, 
                    Remark = "Night seller",
                    Email = "gumball@foodshop.com",
                    Password = "Gumball123",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Employee
                {
                    EmployeeID = 6,
                    EmployeeName = "Gumball",
                    DateBirth = new DateOnly(2001, 11, 11),
                    Address = "Siem Reap",
                    Phone = "086555666",
                    JobId = 4,
                    RoleId = 3,
                    Remark = "Night seller",
                    Email = "darwin@foodshop.com",
                    Password = "Darwin123",
                    CreatedAt = new DateTime(2026, 5, 7)
                }
            );

            // ------------------ Seed Food Categories ------------------ //
            modelBuilder.Entity<Food_Categories>().HasData(
                new Food_Categories
                {
                    CategoryID = 1,
                    CategoryName = "Fast Food",
                    Descriptions = "Burgers, pizza, fried chicken, and snacks",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Food_Categories
                {
                    CategoryID = 2,
                    CategoryName = "Drink",
                    Descriptions = "Drinks like coffee, tea, and soft drinks",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Food_Categories
                {
                    CategoryID = 3,
                    CategoryName = "Desserts",
                    Descriptions = "Sweet foods like cakes and ice cream",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Food_Categories
                {
                    CategoryID = 4,
                    CategoryName = "Snacks",
                    Descriptions = "Light snacks and side dishes",
                    CreatedAt = new DateTime(2026, 5, 7)
                }
            );

            // ------------------ Seed Foods ------------------ //
            modelBuilder.Entity<Foods>().HasData(
                new Foods
                {
                    FoodID = 1,
                    FoodName = "Chicken Burger",
                    FoodCategoryID = 1,
                    FoodImageID = "burger.jpg",
                    Qty = 50,
                    SellPrice = 3.50m,
                    Description = "Grilled chicken burger with fresh vegetables",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Foods
                {
                    FoodID = 2,
                    FoodName = "Cheese Pizza",
                    FoodCategoryID = 1,
                    FoodImageID = "pizza.jpg",
                    Qty = 40,
                    SellPrice = 5.00m,
                    Description = "Classic cheese pizza with mozzarella",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Foods
                {
                    FoodID = 3,
                    FoodName = "Chicken",
                    FoodCategoryID = 1,
                    FoodImageID = "grilled chicken.jpg",
                    Qty = 60,
                    SellPrice = 4.00m,
                    Description = "Crispy fried chicken",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Foods
                {
                    FoodID = 4,
                    FoodName = "Iced Coffee",
                    FoodCategoryID = 2,
                    FoodImageID = "iced_coffee.jpg",
                    Qty = 100,
                    SellPrice = 1.50m,
                    Description = "Cold brewed iced coffee",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Foods
                {
                    FoodID = 5,
                    FoodName = "Milk Tea",
                    FoodCategoryID = 2,
                    FoodImageID = "milk_tea.jpg",
                    Qty = 80,
                    SellPrice = 2.00m,
                    Description = "Sweet milk tea with pearls",
                    CreatedAt = new DateTime(2026, 5, 7)
                },
                new Foods
                {
                    FoodID = 6,
                    FoodName = "French Fries",
                    FoodCategoryID = 1,
                    FoodImageID = "fries.jpg",
                    Qty = 70,
                    SellPrice = 2.50m,
                    Description = "Golden crispy french fries",
                    CreatedAt = new DateTime(2026, 5, 7)
                }
            );

        }
    }
}