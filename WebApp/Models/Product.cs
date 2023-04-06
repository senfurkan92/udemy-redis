namespace WebApp.Models
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    public class ProductDto: Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public decimal Price { get; set; }

        public IFormFile File { get; set; }
    }
}