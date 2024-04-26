using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;


namespace MyCheeseShop.Context
{
    public class UserProvider
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;

        public UserProvider(DatabaseContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public User? GetUserByUsername(string? username)
        {
            
            return _context.Users.FirstOrDefault(user => user.UserName == username);
        }

        public async Task<User?> GetUserByIdAsync(string? id)
        {
            
            return await _context.Users.FindAsync(id);
        }

        public async Task<bool> IsAdmin(User user)
        {
            
            return await _userManager.IsInRoleAsync(user, "Admin");
        }

        public async Task MakeAdmin(User user)
        {
           
            await _userManager.AddToRoleAsync(user, "Admin");
        }

        public async Task RemoveAdmin(User user)
        {
            
            await _userManager.RemoveFromRoleAsync(user, "Admin");
        }

      
    }
}