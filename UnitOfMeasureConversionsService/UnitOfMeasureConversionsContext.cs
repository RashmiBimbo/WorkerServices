
namespace ProductTranslationsService
{
    public class ProductTranslationsContext : DbContext
    {
        public ProductTranslationsContext(DbContextOptions<ProductTranslationsContext> options) : base(options)
        {
        }

        public DbSet<ProductTranslationsTestR> ProductTranslationsTestR { get; set; } = default!;

        //public DbSet<AllProducts> AllProducts { get; set; } = default!;
    }
}
