namespace RestaurantAPI.Models.Entities
{
    public class Products
    {
        public int Id { get; set; }
        public string? ProductName { get; set; } 
        public string? Description { get; set; } 
        public decimal ?Price { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
        public int ?CategoryId { get; set; }
        public bool? IsActive { get; set; } 
        public Category Category { get; set; } = null!;
    }
}
