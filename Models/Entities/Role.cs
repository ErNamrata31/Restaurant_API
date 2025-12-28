namespace RestaurantAPI.Models.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string? RoleName { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
