using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public partial class Mfeldynamics365Context : DbContext
{
    public Mfeldynamics365Context(DbContextOptions<Mfeldynamics365Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AgreementLineReleasedLine> AgreementLineReleasedLines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgreementLineReleasedLine>(entity =>
        {
            entity.HasKey(e => new { e.AgreementLine, e.CustInvoiceTrans, e.ProjInvoiceItem, e.PurchLineDataAreaId, e.PurchLineInventTransId, e.SalesLineDataAreaId, e.SalesLineInventTransId, e.VendInvoiceTrans }).HasName("PK__Agreemen__EA724F76280DFD0F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
