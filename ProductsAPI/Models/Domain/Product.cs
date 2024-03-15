namespace ProductsAPI.Models.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }

        public string? ProductDescription { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set;}
        public Category Category { get; set; }

        public string SupplierId { get; set; }
        public Supplier Supplier { get; set; }

       


    }
}
