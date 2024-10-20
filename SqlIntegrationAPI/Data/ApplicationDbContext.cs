using SqlIntegrationAPI.Models;
using Microsoft.EntityFrameworkCore;
using CitiesManager.WebAPI.Models;

namespace SqlIntegrationAPI.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public virtual DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ESIAngularApp;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False", sqlOptions =>
            sqlOptions.EnableRetryOnFailure(maxRetryCount: 2, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null));

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().HasData(
             new City() { CityID = Guid.Parse("BF160CFD-E693-4C6A-9417-037B4501EC9B"), CityName = "New York" });

            modelBuilder.Entity<City>().HasData(
             new City() { CityID = Guid.Parse("858462EF-5587-48D5-8DB3-392938699F42"), CityName = "London" });
        }
    }
}
