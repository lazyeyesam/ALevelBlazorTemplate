using Microsoft.AspNetCore.Identity;

namespace MyCheeseShop.Model
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
            
        public string PostCode { get; set; }
        public object Orders { get; internal set; }
    }
}
