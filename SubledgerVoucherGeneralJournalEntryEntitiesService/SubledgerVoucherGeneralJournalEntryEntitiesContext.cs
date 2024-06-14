
namespace SubledgerVoucherGeneralJournalEntryEntitiesService
{
    public class SubledgerVoucherGeneralJournalEntryEntitiesContext : DbContext
    {
        public SubledgerVoucherGeneralJournalEntryEntitiesContext(DbContextOptions<SubledgerVoucherGeneralJournalEntryEntitiesContext> options) : base(options)
        {
        }

        public DbSet<SubledgerVoucherGeneralJournalEntryEntitiesTestR> SubledgerVoucherGeneralJournalEntryEntitiesTestR { get; set; } = default!;

        //public DbSet<SubledgerVoucherGeneralJournalEntryEntities> SubledgerVoucherGeneralJournalEntryEntities { get; set; } = default!;
    }
}
