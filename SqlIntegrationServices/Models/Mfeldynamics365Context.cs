using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public partial class MFELDynamics365Context : DbContext
{
    public MFELDynamics365Context()
    {
    }

    public MFELDynamics365Context(DbContextOptions<MFELDynamics365Context> options)
        : base(options)
    {
    }


    public virtual DbSet<ProdCalcTranss> ProdCalcTranss { get; set; }


    public virtual DbSet<ProductCategoryAssignments> ProductCategoryAssignments { get; set; }


    public virtual DbSet<VendorInvoiceLines> VendorInvoiceLines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=10.10.1.138;Initial Catalog=MFELDynamics365;User ID=sa;Password='=*fj9*N*uLBRNZV';Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProdCalcTranss>(entity =>
        {
            entity.HasKey(e => new { e.CollectRefLevel, e.CollectRefProdId, e.dataAreaId, e.InventDimId, e.LineNum }).HasName("PK__ProdCalc__32B051733F6D91B8");
        });

        modelBuilder.Entity<ProductCategoryAssignments>(entity =>
        {
            entity.HasKey(e => new { e.ProductCategoryHierarchyName, e.ProductCategoryName, e.ProductNumber }).HasName("PK__ProductC__6C5E4C88D08E7633");
        });

        modelBuilder.Entity<VendorInvoiceLines>(entity =>
        {
            entity.HasKey(e => new { e.dataAreaId, e.HeaderReference, e.InvoiceLineNumber }).HasName("PK__VendorIn__D5CA6BFFA189E2B4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
