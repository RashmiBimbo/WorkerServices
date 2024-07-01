
namespace AllProductsService
{
    public class AllProductsContext : DbContext
    {
        public AllProductsContext(DbContextOptions<AllProductsContext> options) : base(options)
        {
        }

        public DbSet<AllProductsTestR> AllProductsTestR { get; set; } = default!;

        //public DbSet<AllProducts> AllProducts { get; set; } = default!;
    }
}
