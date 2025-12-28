namespace RestaurantAPI.Models.Entities
{
    public class EmployeeRole
    {
        public int Id { get; set; }
        public string? RoleName { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
