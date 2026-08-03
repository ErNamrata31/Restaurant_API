namespace RestaurantAPI.Models.Entities
{
    public class RoleRight
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? MenuId { get; set; }
        public int? SubMenuId { get; set; }
        public bool? CanView { get; set; }
        public bool? CanAdd { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanUpdate { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public SubMenuMaster? SubMenuMaster { get; set; }

    }
}
