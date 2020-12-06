using Microsoft.EntityFrameworkCore;

namespace SalesCore.Models
{
    public class SalesCoreContext : DbContext
    {
        public SalesCoreContext (DbContextOptions<SalesCoreContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
