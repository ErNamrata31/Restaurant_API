namespace RestaurantAPI.Models.DTOs
{
    public class CategoryDTO
    {
        public int? Id { get; set; }
        public string? CategoryName { get; set; }
        public bool? IsDeleted { get; set; } = false;
    }
}
