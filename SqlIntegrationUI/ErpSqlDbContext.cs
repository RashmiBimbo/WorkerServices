
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SqlIntegrationUI.Models;
using System.Reflection;
using Microsoft.AspNetCore.Identity;

namespace SqlIntegrationUI
{
    public class ErpSqlDbContext(DbContextOptions<ErpSqlDbContext> options) : IdentityDbContext<IdentityUser>(options)
    {
        public DbSet<DBServiceDetail> DBServiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DBServiceDetail>(entity =>
            {
                // Primary Key
                entity.HasKey(e => e.RecId);

                // Property Configurations
                entity.Property(e => e.RecId)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn(1, 1);  // Identity column

                entity.Property(e => e.Enable)
                    .HasDefaultValue(true);  // Default value for Enable (bool)

                entity.Property(e => e.Name)
                    .IsRequired();  // Required property

                entity.Property(e => e.Endpoint)
                    .IsRequired();  // Required property

                entity.Property(e => e.QueryString)
                    .HasDefaultValue("cross-company=true");  // Default value for QueryString

                entity.Property(e => e.Period)
                    .IsRequired()
                    .HasDefaultValue(30);  // Required and default value for Period

                entity.Property(e => e.Table)
                    .IsRequired();  // Required property

                entity.Property(e => e.TableAltered)
                    .IsRequired()
                    .HasDefaultValue(false);  // Required and default value for TableAltered

                entity.Property(e => e.Status)
                    .HasMaxLength(255)
                    .HasDefaultValue("Running");  // Max length for Status

                entity.Property(e => e.LastRun)
                    .HasMaxLength(255);  // Max length for LastRun

                entity.Property(e => e.TotalRecordsTracked);

                entity.Property(e => e.TotalRecordsAdded);

                entity.Property(e => e.TotalRecordsUpdated);

                entity.Property(e => e.TimeTaken);

                entity.Property(e => e.NextRun)
                    .HasMaxLength(255);  // Max length for NextRun

                entity.Property(e => e.Columns)
                    .IsRequired();  // Required property

                entity.Property(e => e.CreatedDate)
                    .IsRequired()
                    .HasDefaultValueSql("GETDATE()");  // Default to current date

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(255);  // Required and max length for CreatedBy

                entity.Property(e => e.ModifiedDate)
                    .HasMaxLength(255);  // Max length for ModifiedDate

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(255);  // Max length for ModifiedBy
            });
        }
    }
}