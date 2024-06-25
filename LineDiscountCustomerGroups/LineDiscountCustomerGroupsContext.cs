
namespace SqlIntegrationServices
{
    public class LineDiscountCustomerGroupsContext : DbContext
    {
        public LineDiscountCustomerGroupsContext(DbContextOptions<LineDiscountCustomerGroupsContext> options) : base(options)
        {
        }

        public DbSet<LineDiscountCustomerGroupsTestR> LineDiscountCustomerGroupsTestR { get; set; } = default!;

        //public DbSet<SubledgerVoucherGeneralJournalEntryEntities> SubledgerVoucherGeneralJournalEntryEntities { get; set; } = default!;
    }
}
