namespace RestaurantAPI.Models.Entities
{
    public class SubMenuMaster
    {
        public int? Id { get; set; }
        public string? SubMenuName { get; set; }
        public int? MenuId { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public MenuMaster? MenuMaster { get; set; }
        public ICollection<RoleRight>? RoleRights { get; set; }
    }
}
