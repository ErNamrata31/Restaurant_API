using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data.Seed;
using RestaurantAPI.Models.DTOs;
using RestaurantAPI.Models.Entities;
using System.Reflection.Emit;

namespace RestaurantAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            RoleSeed.Seed(modelBuilder);
            EmployeeRoleSeed.EmpSeed(modelBuilder);
            modelBuilder.Entity<Branch>().HasIndex(b => b.BranchCode).IsUnique();
            modelBuilder.Entity<Category>();
            modelBuilder.Entity<Products>();
            modelBuilder.Entity<EmployeeRole>();
            modelBuilder.Entity<Employee>().HasOne(e => e.EmployeeRole).WithMany(r => r.Employees).HasForeignKey(e => e.empRoleId);
            modelBuilder.Entity<TableRecord>();
        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TableRecord> TableRecords { get; set; }
    }
}

