
namespace BudgetRegisterEntryLinesService
{
    public class CustomerItemsContext : DbContext
    {
        public CustomerItemsContext(DbContextOptions<CustomerItemsContext> options) : base(options)
        {
        }

        public DbSet<CustomerItemsTestR> CustomerItemsTestR { get; set; } = default!;

        //public DbSet<CustomerItems> CustomerItems { get; set; } = default!;
    }
}
