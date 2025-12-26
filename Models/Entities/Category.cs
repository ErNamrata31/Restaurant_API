using RestaurantAPI.Models.DTOs;

namespace RestaurantAPI.Models.Entities
{
    public class Category
    {
        public int? Id { get; set; }
        public string? CategoryName { get; set; }
        public bool? IsDeleted { get; set; }
        public ICollection<Products> Products { get; set; } = new List<Products>();
    }
}
