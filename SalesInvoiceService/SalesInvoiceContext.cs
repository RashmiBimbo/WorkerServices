using Microsoft.EntityFrameworkCore;
using SalesInvoiceService;

namespace SalesInvoiceService
{
    public class SalesInvoiceContext : DbContext
    {
        public SalesInvoiceContext()
        {
        }

        public SalesInvoiceContext(DbContextOptions<SalesInvoiceContext> options) : base(options)
        {
        }

        public DbSet<CustInvoiceJourTestR> CustInvoiceJourTestR { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=10.10.1.138;Initial Catalog=MFELDynamics365;User ID=sa;Password='=*fj9*N*uLBRNZV';Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

    }
}