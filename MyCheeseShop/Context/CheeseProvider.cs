using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;
namespace MyCheeseShop.Context


{
   
    
    
    public class CheeseProvider
    {
        private readonly DatabaseContext _context;
        public CheeseProvider(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<Cheese>> GetAllCheesesAsync()
        {
            return await _context.Cheeses.OrderBy(cheese => cheese.Name).ToListAsync();
        }
        public Cheese? GetCheese(int id)
        {
            return _context.Cheeses.Find(id);
        }
    }
}
