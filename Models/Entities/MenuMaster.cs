namespace RestaurantAPI.Models.Entities
{
    public class MenuMaster
    {
        public int Id { get; set; }
        public string? MenuName { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }= false;
        public ICollection<SubMenuMaster>? SubMenuMasters { get; set; }
    }
}
