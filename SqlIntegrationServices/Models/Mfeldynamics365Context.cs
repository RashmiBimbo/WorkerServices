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


    public virtual DbSet<FormulaVersion2s> FormulaVersion2s { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FormulaVersion2s>(entity =>
        {
            entity.HasKey(e => new { e.DataAreaId, e.FormulaId, e.IsActive, e.ProductionSiteId }).HasName("PK__FormulaV__CA95C516D9DD3DA6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
