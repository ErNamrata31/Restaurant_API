

namespace RestaurantAPI.Models.DTOs
{
    public class ProductCreateDTO
    {
        public int? Id { get; set; }
        public int? CategoryId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? Price { get; set; }
        public bool?  IsActive { get; set; }
        public bool? IsDeleted { get; set; } = false;

    }
    public class ProductReadDTO
    {
        public int Id { get; set; }
        public string? ProductName { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool? IsActive { get; set; }

        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; } = string.Empty;
    }
   


}
