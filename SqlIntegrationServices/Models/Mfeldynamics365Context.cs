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


    public virtual DbSet<KPIStdDatas> KPIStdDatas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KPIStdDatas>(entity =>
        {
            entity.HasKey(e => new { e.BagQty, e.dataAreaId, e.InventSiteId, e.ItemId, e.KPIBatchNo }).HasName("PK__KPIStdDa__CC15B33D3E99CA6A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
