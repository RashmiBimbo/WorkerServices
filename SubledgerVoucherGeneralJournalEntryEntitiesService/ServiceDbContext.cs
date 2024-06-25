
namespace SqlIntegrationServices
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {
        }

        public DbSet<SubledgerVoucherGeneralJournalEntryEntitiesTestR> SubledgerVoucherGeneralJournalEntryEntitiesTestR { get; set; } = default!;

        public DbSet<AllProductsTestR> AllProductsTestR { get; set; } = default!;

        public DbSet<UnitOfMeasureConversionsTestR> UnitOfMeasureConversionsTestR { get; set; } = default!;

    }
}