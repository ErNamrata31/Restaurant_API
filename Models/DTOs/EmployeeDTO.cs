namespace RestaurantAPI.Models.DTOs
{
    public class EmployeeCreateDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? EmailId { get; set; }
        public string? ContactNo { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int RoleId { get; set; }
        public string? Status { get; set; }
        public decimal Salary { get; set; }
        public bool IsDeleted { get; set; }=false;
        public bool IsApproved { get; set; }
        public DateOnly? DateOfJoining { get; set; }

    }
    public class EmployeeReadDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? EmailId { get; set; }
        public string? ContactNo { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int RoleId { get; set; }
        public string? Status { get; set; }
        public decimal Salary { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsApproved { get; set; }
        public DateOnly? DateOfJoining { get; set; } 
        public string? RoleName { get; set; }

    }
}
