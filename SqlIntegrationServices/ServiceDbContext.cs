
namespace SqlIntegrationServices
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {
        }

        public DbSet<SubledgerVoucherGeneralJournalEntryEntitiesTest> SubledgerVoucherGeneralJournalEntryEntitiesTest { get; set; } = default!;

        public DbSet<AllProductsTest> AllProductsTest { get; set; } = default!;

        public DbSet<UnitOfMeasureConversionsTest> UnitOfMeasureConversionsTest { get; set; } = default!;

        public DbSet<CustomerItemsTest> CustomerItemsTest { get; set; } = default!;

        public DbSet<HSNCodes> HSNCodes { get; set; } = default!;

        public DbSet<HSNCodesTest> HSNCodesTest { get; set; } = default!;

    }
}