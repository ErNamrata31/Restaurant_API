using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAPI.Models.Entities
{
    public class Orders
    {
        public int Id { get; set; }

        public int tableId { get; set; }
        public decimal totalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderStatus { get; set; }
        [ForeignKey("tableId")]
        public virtual TableRecord TableRecord { get; set; }
        public DateTime createdAt { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }= new List<OrderItem>();
    }
}
