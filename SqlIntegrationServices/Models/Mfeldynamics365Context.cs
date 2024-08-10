using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SqlIntegrationServices;

public partial class MFELDynamics365Context : DbContext
{
    public MFELDynamics365Context(DbContextOptions<MFELDynamics365Context> options)
        : base(options)
    {
    }


    public virtual DbSet<PartyLocationPostalAddressesV2> PartyLocationPostalAddressesV2 { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PartyLocationPostalAddressesV2>(entity =>
        {
            entity.HasKey(e => new { e.LocationId, e.PartyNumber, e.ValidFrom }).HasName("PK__PartyLoc__CB275808551A1BF2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
