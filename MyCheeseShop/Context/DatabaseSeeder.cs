using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            await _context.Database.MigrateAsync();
            if (!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

                var adminEmail = "admin@cheese.com";
                var adminPassword = "Cheese123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminPassword,
                    FirstName = "Admin",
                    LastName = "User",
                    Address = "123 Admin Street",
                    City = "Adminville",
                    PostCode = "AD12 MIN"
                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.AddToRoleAsync(admin, "Admin");
            }

            if (!_context.Cheeses.Any())
            {
                var cheeses = GetCheeses();
                _context.Cheeses.AddRange(cheeses);
                await _context!.SaveChangesAsync();
            }
        }

        public async Task<List<Cheese>> GetAllCheesesAsync()
        {
            return await _context.Cheeses.OrderBy(cheese => cheese.Name).ToListAsync();
        }

        public Cheese? GetCheese(int id)
        {
            
            return _context.Cheeses.Find(id);
        }

        private List<Cheese> GetCheeses()
        {
            return
            [
                new Cheese { Name = "Gouda Gauntlet", Type = "Semi-Hard", Description = "This smooth and creamy Dutch cheese will have you saying 'gouda' for more! Its nutty flavor is a delightful capture for your taste buds.", Strength = "Medium", Price = 8.99m },
                new Cheese { Name = "Camembert Cage", Type = "Soft-Ripened", Description = "Don't get brie-lieve this velvety French cheese is for the faint of heart! Its rich, earthy flavors will hold you captive in a delicious cage.", Strength = "Mild", Price = 10.49m },
                new Cheese { Name = "Cheddar Cavern", Type = "Hard", Description = "This aged English cheese is a sharp and tangy treasure waiting to be unearthed. Be warned, its crumbly texture and deep orange color might have you saying 'cheddar about that' second helping!", Strength = "Strong", Price = 7.99m },
                new Cheese { Name = "Brie Bond", Type = "Soft-Ripened", Description = "This luxurious French cheese is a brie-lliant indulgence. Its delicate, creamy taste will form an unbreakable bond with your palate.", Strength = "Mild", Price = 11.99m },
                new Cheese { Name = "Blue Vein Vortex", Type = "Blue", Description = "A pungent and flavorful cheese with a swirl of blue veins, this is a taste adventure with a bit of a bite! Be prepared to get swept away in the blue vein vortex.", Strength = "Strong", Price = 9.99m },
                new Cheese { Name = "Mozzarella Maze", Type = "Fresh", Description = "The soft, stretchy texture of this Italian classic is a mozzarella maze for your fork! Ideal for melting on pizzas or layering in salads, it's a cheesy escape you won't want to miss.", Strength = "Mild", Price = 6.49m },
                new Cheese { Name = "Parmesan Prison", Type = "Hard", Description = "This aged Italian cheese boasts a granular texture and rich, nutty flavor. A sprinkle over pasta or salads is all it takes to become a prisoner (willingly) in the Parmesan Prison.", Strength = "Strong", Price = 12.99m },
                new Cheese { Name = "Swiss Snare", Type = "Semi-Hard", Description = "Don't let the iconic holes fool you, this Swiss cheese with its slightly sweet and nutty taste will snare your senses! Smooth and delightful, it's a cheesy capture you won't mind.", Strength = "Medium", Price = 9.49m },
                new Cheese { Name = "Feta Fortress", Type = "Soft", Description = "This crumbly and tangy Greek cheese is a flavorful fortress for your salads or pastries. One bite and you'll be feta-ally hooked!", Strength = "Mild", Price = 7.99m },
                new Cheese { Name = "Havarti Hold", Type = "Semi-Soft", Description = "This Danish cheese with its creamy, buttery taste and mild, nutty profile is a flavor haven you won't want to leave. But be warned, once you try it, you might be put on Havarti hold!", Strength = "Medium", Price = 8.99m },
                new Cheese { Name = "Pepper Jack Ambush", Type = "Semi-Soft", Description = "Get ready for a taste bud ambush with this spicy American cheese! Infused with jalapeño peppers, its zesty kick and creamy texture are a delightful surprise for your sandwich or burger.", Strength = "Medium", Price = 7.99m },
                new Cheese { Name = "Colby Coil", Type = "Semi-Hard", Description = "This American cheese, similar to cheddar but milder, is a cheesy coil of deliciousness. With its firm texture and smooth finish, it's perfect for snacking or melting, and won't leave you feeling Colby-whelmed.", Strength = "Mild", Price = 6.99m },
                new Cheese { Name = "Gorgonzola Grip", Type = "Blue", Description = "This Italian blue cheese with its bold, tangy flavor and crumbly texture is a taste bud grip you won't soon forget. Perfect for adding depth to salads or pairing with fruits and nuts, it's a cheese with an attitude.", Strength = "Strong", Price = 10.99m },
                new Cheese { Name = "Provolone Pounce", Type = "Semi-Hard", Description = "This Italian cheese with its mild and slightly smoky flavor is a flavor pounce waiting to happen! Enjoy it in sandwiches, pasta dishes, or on its own, but be prepared to be provolone-d by its deliciousness.", Strength = "Mild", Price =12.40m },
                new Cheese { Name = "Rogue River Ransom", Type = "Semi-Soft", Description = "This American cheese from Oregon is aged with syrah grape leaves soaked in brandy. This complex cheese offers a fruity and floral aroma with hints of wine and a sharp, tangy finish. Be prepared, the flavor is so good it might hold you hostage!", Strength = "Strong", Price = 15.99m },
                new Cheese { Name = "Tetilla Tether", Type = "Semi-Soft", Description = "Nicknamed 'Little Breast' for its unique shape, this Spanish cheese is made from cow's milk and boasts a mild, buttery flavor with a slightly sweet finish. (Rind typically not eaten) Don't let the name fool you, this cheese will tether your taste buds with its delightful flavor.", Strength = "Mild", Price = 9.99m },
                new Cheese { Name = "Halloumi Hold", Type = "Brined", Description = "A unique Cypriot cheese that can be grilled or fried without melting! Halloumi offers a salty flavor and a springy, firm texture, perfect for enjoying grilled with vegetables or kebabs. This cheese is a flavor hold-up you won't want to miss!", Strength = "Medium", Price = 11.49m },
                new Cheese { Name = "Vacherin Vineyard Trap", Type = "Semi-Soft", Description = "A Swiss cheese washed in white wine or marc (grape brandy) during aging. This cheese boasts a pungent aroma and a strong, earthy flavor with a hint of fruitiness. Be warned, the aroma of this cheese might trap you in for a closer sniff (and taste)!", Strength = "Strong", Price = 13.99m },
                new Cheese { Name = "Mesclun Manor", Type = "Mixed Milk", Description = "An Italian cheese blend of sheep, goat, and cow's milk. Mesclun offers a complex flavor profile that varies depending on the milk proportions, ranging from mild and creamy to sharp and tangy. Get ready to get lost in the delightful maze of flavors offered by this unique cheese!", Strength = "Varies", Price = 10.99m }
            ];
        }
    }
}