
namespace SqlIntegrationServices
{
    public class HSNCodesContext : DbContext
    {
        public HSNCodesContext(DbContextOptions<HSNCodesContext> options) : base(options)
        {
        }

        public DbSet<HSNCodesTestR> HSNCodesTestR { get; set; } = default!;

        //public DbSet<SubledgerVoucherGeneralJournalEntryEntities> SubledgerVoucherGeneralJournalEntryEntities { get; set; } = default!;
    }
}
