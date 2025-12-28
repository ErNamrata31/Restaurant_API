namespace RestaurantAPI.Models.DTOs
{
    public class StaffCreateDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? ContactNo { get; set; }
        public string? EmailId { get; set; }
        public string? Address { get; set; }
        public int? PinCode { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? empRoleId { get; set; }

    }
    public class StaffReadDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? ContactNo { get; set; }
        public string? EmailId { get; set; }
        public string? Address { get; set; }
        public int? PinCode { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? empRoleId { get; set; }
        public string ? EmpRoleName { get; set; }

    }
}
