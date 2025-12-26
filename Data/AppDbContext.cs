using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models.DTOs;
using RestaurantAPI.Models.Entities;

namespace RestaurantAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Branch>().HasIndex(b => b.BranchCode).IsUnique();
            modelBuilder.Entity<Category>();
            modelBuilder.Entity<Products>();
        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Product { get; set; }
    }
}
