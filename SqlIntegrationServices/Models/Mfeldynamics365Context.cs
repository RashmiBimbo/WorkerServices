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


    public virtual DbSet<VendTransDatasEntity> VendTransDatasEntity { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VendTransDatasEntity>(entity =>
        {
            entity.HasKey(e => new { e.AccountNum, e.dataAreaId, e.RecId1 }).HasName("PK__VendTran__910D226CCAEF0A96");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
