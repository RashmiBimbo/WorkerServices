
namespace PriceCustomerGroupsService
{
    public class PriceCustomerGroupsContext : DbContext
    {
        public PriceCustomerGroupsContext(DbContextOptions<PriceCustomerGroupsContext> options) : base(options)
        {
        }

        public DbSet<PriceCustomerGroupsTestR> PriceCustomerGroupsTestR { get; set; } = default!;

        //public DbSet<AllProducts> AllProducts { get; set; } = default!;
    }
}
