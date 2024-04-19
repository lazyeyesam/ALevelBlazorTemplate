namespace MyCheeseShop.Model
{
    public class Cheese
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Type { get; set; } 
        public string Description { get; set; }   
        public string Strength { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

    }
}
