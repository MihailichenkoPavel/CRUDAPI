using System.Data.Entity;

namespace CRUDAPI.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("DbConnection")
        { }

        public DbSet<Product> Products { get; set; }
    }
}