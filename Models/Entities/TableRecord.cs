namespace RestaurantAPI.Models.Entities
{
    public class TableRecord
    {
        public int Id { get; set; }
        public string? TableNumber { get; set; }
        public string BranchCode { get; set; } = string.Empty;
        public int SeatingCapacity { get; set; }
        public string? TableQRCode { get; set; }
        public bool IsOccupied { get; set; }
        public bool IsDeleted { get; set; }
        public int modifiedBy { get; set; }
        public bool IsModified { get; set; } 
    }
}
