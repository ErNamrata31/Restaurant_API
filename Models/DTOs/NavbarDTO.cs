using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Models.DTOs
{
    public class NavbarDTO
    {
        public string? SubMenuName { get; set; }
        public string? MenuName { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }
        public List<int?> roleIds { get; set; } = new List<int?>();
        public List<int?> permissions { get; set; } = new List<int?>();
    }
    public class NavbarResponseDTO
    {
        public string? Title { get; set; }
        public List<NavbarDTO> items { get; set; }
    }

}
