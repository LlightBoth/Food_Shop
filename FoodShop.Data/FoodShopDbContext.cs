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

            // Customer (Buyer) -> Invoices (one-to-many)
            modelBuilder.Entity<Invoices>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            // Roles → ByEmployee (optional)
            modelBuilder.Entity<Roles>()
                .HasOne(r => r.ByEmployee)
                .WithMany() // optional, no navigation in Employee
                .HasForeignKey(r => r.ByEmployeeID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}