
using System.Reflection;

namespace SqlIntegrationServices
{
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            IEnumerable<Type> entityTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.GetCustomAttributes<PrimaryKeyAttribute>().Any());

            foreach (Type entityType in entityTypes)
            {
                if (entityType.FullName.Contains("Base", StrComp)) continue;

                var primaryKeyAttribute = entityType.GetCustomAttribute<PrimaryKeyAttribute>();
                IReadOnlyList<string> primaryKeyProperties = primaryKeyAttribute.PropertyNames;

                modelBuilder.Entity(entityType).HasKey([.. primaryKeyProperties]);
            }
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();

                foreach (var property in entityType.GetProperties())
                {
                    var columnName = property.GetColumnName();

                    // Check if the property name doesn't match the column name
                    if (property.Name != columnName)
                    {
                        // Map the property to the column name with underscores
                        modelBuilder.Entity(entityType.ClrType)
                                    .Property(property.Name)
                                    .HasColumnName(columnName);
                    }
                }
            }
        }
    }
}