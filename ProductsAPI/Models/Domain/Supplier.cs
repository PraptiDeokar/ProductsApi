namespace ProductsAPI.Models.Domain
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }

        public string? Image { get; set; }
    }
}
