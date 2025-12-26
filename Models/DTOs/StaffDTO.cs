namespace RestaurantAPI.Models.DTOs
{
    public class StaffDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? ContactNo { get; set; }
        public string? EmailId { get; set; }
        public string? Address { get; set; }
        public int? PinCode { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }

    }
}
