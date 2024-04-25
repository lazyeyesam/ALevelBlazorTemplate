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

        public async Task AddCheeseAsync(Cheese cheese)
        {
            _context.Cheeses.Add(cheese);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCheeseAsync(Cheese cheese)
        {
            _context.Cheeses.Update(cheese);
            await _context.SaveChangesAsync();
        }
    }
}