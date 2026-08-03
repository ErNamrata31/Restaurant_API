using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int orderId { get; set; }
        public int productId { get; set; }
        [ForeignKey("orderId")]
        public virtual Orders Orders { get; set; } = null;
        public int quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }
        public string ItemStatus { get; set; } = "pending";
        public string notes { get; set; }
    }
}
