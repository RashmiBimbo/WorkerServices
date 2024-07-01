namespace BudgetRegisterEntryHeadersService
{
    public class BudgetRegisterEntryHeadersContext : DbContext
    {
        public BudgetRegisterEntryHeadersContext(DbContextOptions<BudgetRegisterEntryHeadersContext> options) : base(options)
        {
        }

        public DbSet<BudgetRegisterEntryHeadersTestR> BudgetRegisterEntryHeadersTestR { get; set; } = default!;

        //public DbSet<BudgetRegisterEntryHeaders> BudgetRegisterEntryHeaders { get; set; } = default!;
    }
}
