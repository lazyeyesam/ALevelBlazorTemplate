namespace MyCheeseShop.Model
{
    public class ShoppingCart
    {
        public event Action? OnCartUpdated;
        private List<CartItem> _items;

        public ShoppingCart()
        {
            _items = [];
        }



        public IEnumerable<CartItem> GetItems()
        {
            return _items;
        }

        public void AddItem(Cheese cheese, int quantity)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item == null)
            {
                _items.Add(new CartItem { Cheese = cheese, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }

            OnCartUpdated?.Invoke();
        }
        public int Count()
        {
            
            return _items.Count;
        }

        public void RemoveItem(Cheese cheese)
        {
            _items.RemoveAll(item => item.Cheese.Id == cheese.Id);
            OnCartUpdated?.Invoke();
        }

        public void RemoveItem(Cheese cheese, int quantity)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item is not null)
            {
                item.Quantity -= quantity;
                if (item.Quantity <= 0)
                    _items.Remove(item);
            }
            OnCartUpdated?.Invoke();
        }

        public decimal Total()
        {
            // sum the price of all items in the cart
            return _items.Sum(item => item.Cheese.Price * item.Quantity);
        }

        public void SetItems(IEnumerable<CartItem> items)
        {
            _items = items.ToList();
            OnCartUpdated?.Invoke();
        }

 
    }
}