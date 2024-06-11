namespace BudgetModelService
{
    public class BudgetModelContext : DbContext
    {
        public BudgetModelContext(DbContextOptions<BudgetModelContext> options) : base(options)
        {
        }

        public DbSet<BudgetModelTestR> BudgetModelTestR { get; set; } = default!;

        public DbSet<BudgetModel> BudgetModel { get; set; } = default!;
    }
}
