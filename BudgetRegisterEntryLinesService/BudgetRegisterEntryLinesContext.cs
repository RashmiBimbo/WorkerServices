
namespace CustomerItemsService
{
    public class BudgetRegisterEntryLinesContext : DbContext
    {
        public BudgetRegisterEntryLinesContext(DbContextOptions<BudgetRegisterEntryLinesContext> options) : base(options)
        {
        }

        public DbSet<BudgetRegisterEntryLinesTestR> BudgetRegisterEntryLinesTestR { get; set; } = default!;

        //public DbSet<BudgetRegisterEntryLines> BudgetRegisterEntryLines { get; set; } = default!;
    }
}
