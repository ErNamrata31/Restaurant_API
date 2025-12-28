using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models.Entities;

namespace RestaurantAPI.Data.Seed
{
    public class EmployeeRoleSeed
    {
        public static void EmpSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeRole>().HasData(
                new EmployeeRole { Id = 1, RoleName = "Waiter" },
                new EmployeeRole { Id = 2, RoleName = "Kitchen" },
                new EmployeeRole { Id = 3, RoleName = "Manager" }
            );
        }
    }
}
