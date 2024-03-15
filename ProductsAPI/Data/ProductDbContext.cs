using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models.Domain;

namespace ProductsAPI.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
                
        }

        public DbSet<Category> categoties{ get; set; }
        
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Product> products { get; set; }

    }
}
