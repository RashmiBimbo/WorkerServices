
namespace SalesInvoiceHeaderService
{
    public class SalesInvoiceHeadersContext : DbContext
    {
        public SalesInvoiceHeadersContext(DbContextOptions<SalesInvoiceHeadersContext> options) : base(options)
        {
        }

        public DbSet<CustInvoiceJourTestR> CustInvoiceJourTestR { get; set; } = default!;

        public DbSet<CustInvoiceJour> CustInvoiceJour { get; set; } = default!;
    }
}
