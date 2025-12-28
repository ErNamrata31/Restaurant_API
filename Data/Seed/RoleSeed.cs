using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models.Entities;

namespace RestaurantAPI.Data.Seed
{
    public class RoleSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "Manager" },
                new Role { Id = 3, RoleName = "Staff" },
                new Role { Id = 4, RoleName = "Customer" }
            );
        }
    }
}
