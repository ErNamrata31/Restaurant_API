namespace RestaurantAPI.Models.Entities
{
    public class CartItems
    {
        public int Id { get; set; }
        public int cartId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public string notes { get; set; }
    }
}
