namespace ProductsAPI.Models.DTO
{
    public class SupplierDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }

        public string? Image { get; set; }
    }
}
