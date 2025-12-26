using RestaurantAPI.Services;

namespace RestaurantAPI.Models.DTOs
{
    public class BranchDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? BranchCode { get; set; }
        public string? Address { get; set; }
        public bool? IsDelete { get; set; } = false;
    }
}
