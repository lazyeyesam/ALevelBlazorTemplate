using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;
using static MyCheeseShop.Model.Order;

namespace MyCheeseShop.Context
{
    public class OrderProvider
    {
        private readonly DatabaseContext _context;

        public OrderProvider(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Order>?> GetOrdersAsync(User? user)
        {
            if (user == null) return null;

           
            return await _context.Orders
                .Where(order => order.User.UserName == user.UserName)
                .Include(order => order.Items)
                .ThenInclude(item => item.Cheese)
                .OrderByDescending(order => order.Created)
                .ToListAsync();
        }

        public async Task CreateOrder(User user, IEnumerable<CartItem> items)
        {
            
            var order = new Order
            {
                User = user,
                Items = items.Select(item => new OrderItem
                {
                    Cheese = item.Cheese,
                    Quantity = item.Quantity,
                }).ToList(),
                Created = DateTime.Now,
                Status = OrderStatus.Placed
            };

            
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }



    }
}
