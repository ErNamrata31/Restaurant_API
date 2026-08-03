using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models.Entities
{
    public class Carts
    {
        public int Id { get; set; }
        public int tableId { get; set; }
        public string status { get; set; }

        [ForeignKey("tableId")]
        public virtual TableRecord TableRecord { get; set; } = null;
        public DateTime createdAt { get; set; }
        public ICollection<CartItems> CartItems { get; set; }=new List<CartItems>();
    }
}
