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
                    Email = adminEmail,
                    FirstName = "Admin",
                    LastName = "User",
                    Address = "123 Admin Street",
                    City = "Adminville",
                    PostCode = "AD12 MIN"
                };

                await _userManager.CreateAsync(admin, adminPassword);
                await _userManager.CreateAsync(admin, "Admin");


            }
            if (!_context.Cheeses.Any())
            {
                var cheeses = GetCheeses();
                _context.Cheeses.AddRange(cheeses);
                await _context!.SaveChangesAsync();
            }


        }
        public List<Cheese> GetCheeses()
        {
            return
            [
                new Cheese { Name = "Gouda Gold", Type = "Semi-Hard", Description = "A smooth and creamy cheese originating from the Netherlands, known for its slightly nutty flavor and golden hue.", Strength = "Medium", Price = 8.99m },
                new Cheese { Name = "Camembert Classic", Type = "Soft-Ripened", Description = "A quintessential French cheese with a velvety rind and creamy interior, boasting rich, earthy flavors with hints of mushroom.", Strength = "Mild", Price = 10.49m },
                new Cheese { Name = "Cheddar Supreme", Type = "Hard", Description = "An aged English cheese with a sharp and tangy taste, characterized by its crumbly texture and deep orange color.", Strength = "Strong", Price = 7.99m },
                new Cheese { Name = "Brie Royale", Type = "Soft-Ripened", Description = "A luxurious French cheese with a buttery texture and delicate, creamy taste, perfect for pairing with fruits and crackers.", Strength = "Mild", Price = 11.99m },
                new Cheese { Name = "Blue Vein Delight", Type = "Blue", Description = "A pungent and flavorful cheese with distinctive blue veins running throughout, offering a bold and tangy taste experience.", Strength = "Strong", Price = 9.99m },
                new Cheese { Name = "Mozzarella Fresca", Type = "Fresh", Description = "An Italian classic, known for its soft and stretchy texture, ideal for melting on pizzas or layering in caprese salads.", Strength = "Mild", Price = 6.49m },
                new Cheese { Name = "Parmesan Prestige", Type = "Hard", Description = "A renowned Italian cheese with a granular texture and rich, nutty flavor, often grated over pasta dishes or salads.", Strength = "Strong", Price = 12.99m },
                new Cheese { Name = "Swiss Bliss", Type = "Semi-Hard", Description = "A Swiss cheese with a slightly sweet and nutty taste, characterized by its iconic holes and smooth texture.", Strength = "Medium", Price = 9.49m },
                new Cheese { Name = "Feta Fancy", Type = "Soft", Description = "A crumbly and tangy Greek cheese made from sheep's milk, perfect for adding a savory kick to salads or pastries.", Strength = "Mild", Price = 7.99m },
                new Cheese { Name = "Havarti Harmony", Type = "Semi-Soft", Description = "A Danish cheese with a creamy and buttery taste, featuring small irregular holes and a mild, nutty flavor profile.", Strength = "Medium", Price = 8.99m },
                new Cheese { Name = "Pepper Jack Passion", Type = "Semi-Soft", Description = "A spicy American cheese infused with jalapeño peppers, offering a zesty kick and creamy texture, perfect for sandwiches or melting on burgers.", Strength = "Medium", Price = 7.99m },
                new Cheese { Name = "Colby Comfort", Type = "Semi-Hard", Description = "An American cheese similar to cheddar but milder in flavor, featuring a firm texture and smooth finish, great for snacking or melting.", Strength = "Mild", Price = 6.99m },
                new Cheese { Name = "Gorgonzola Glory", Type = "Blue", Description = "An Italian blue cheese with a crumbly texture and bold, tangy flavor, perfect for adding depth to salads or pairing with fruits and nuts.", Strength = "Strong", Price = 10.99m },
                new Cheese { Name = "Provolone Perfection", Type = "Semi-Hard", Description = "An Italian cheese with a mild and slightly smoky flavor, often used for sandwiches, pasta dishes, or eaten on its own as a snack.", Strength = "Medium", Price = 8.49m },
                new Cheese { Name = "Ricotta Riches", Type = "Fresh", Description = "An Italian whey cheese with a creamy texture and slightly sweet flavor, commonly used in desserts, pastries, or as a filling in pasta dishes.", Strength = "Mild", Price = 5.99m },
                new Cheese { Name = "Manchego Majesty", Type = "Hard", Description = "A Spanish cheese made from sheep's milk, featuring a firm texture and nutty flavor with hints of caramel, perfect for pairing with fruits or cured meats.", Strength = "Medium", Price = 11.49m },
                new Cheese { Name = "Goat's Glee", Type = "Soft", Description = "A creamy and tangy cheese made from goat's milk, offering a distinctive flavor profile and smooth texture, ideal for spreading on crackers or toast.", Strength = "Mild", Price = 9.99m },
                new Cheese { Name = "Emmental Elegance", Type = "Semi-Hard", Description = "A Swiss cheese with a mild and nutty taste, featuring large irregular holes and a smooth, buttery texture, perfect for fondue or sandwiches.", Strength = "Medium", Price = 10.99m },
                new Cheese { Name = "Pecorino Passion", Type = "Hard", Description = "An Italian cheese made from sheep's milk, boasting a sharp and salty flavor, often grated over pasta or enjoyed with honey and nuts.", Strength = "Strong", Price = 13.99m },
                new Cheese { Name = "Monterey Jack", Type = "Semi-Soft", Description = "A versatile American cheese with a mild and buttery taste, great for melting on nachos, sandwiches, or adding to omelets for extra creaminess.", Strength = "Medium", Price = 7.49m}

            ];
        }






    }
}