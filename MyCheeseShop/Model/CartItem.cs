namespace MyCheeseShop.Model
{
    public class CartItem
    {
        public Cheese Cheese { get; set; }

        public int Quantity { get; set; }

        public decimal Total => Cheese.Price * Quantity;
    }
}
