namespace SalesOrderService
{
    public class SalesOrderContext : DbContext
    {
        public SalesOrderContext()
        {

        }
        public SalesOrderContext(DbContextOptions<SalesOrderContext> options) : base(options)
        {
        }

        public DbSet<SalesOrderTestPoco> SalesOrderTestPoco { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

    }
}
