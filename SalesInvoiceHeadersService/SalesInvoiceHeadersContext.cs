// SalesInvoiceHeadersContext.cs
using Microsoft.EntityFrameworkCore;

namespace SalesInvoiceHeaderService
{
    [Keyless]
    public class SalesInvoiceHeadersContext : DbContext
    {
        public SalesInvoiceHeadersContext(DbContextOptions<SalesInvoiceHeadersContext> options) : base(options)
        {
        }

        public DbSet<CustInvoiceJourTestR> CustInvoiceJourTestR { get; set; } = default!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CustInvoiceJourTestR>().HasNoKey();
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
