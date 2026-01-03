namespace RestaurantAPI.Models.Entities
{
    public class Employee
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? ContactNo { get; set; }
        public string? EmailId { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? PinCode { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? empRoleId { get; set; }
        public decimal Salary { get; set; }
        public string? Password { get; set; }
        public bool? IsDeleted { get; set; }
        public EmployeeRole? EmployeeRole { get; set; }
    }
}
