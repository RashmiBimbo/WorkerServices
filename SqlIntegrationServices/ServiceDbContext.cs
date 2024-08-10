
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection;

namespace SqlIntegrationServices
{
    public partial class DeserializeJson<T> where T : notnull
    {
        public static T Deserialize(string json) => JsonConvert.DeserializeObject<T>(json, settings: Converter.Settings);
    }
    public class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        {
            //AddDbSets();
        }

        //public DbSet<AllProducts> AllProducts { get; set; } = default!;
        //public DbSet<AllProductsTest> AllProductsTest { get; set; } = default!;
        //public DbSet<BudgetModels> BudgetModels { get; set; } = default!;
        //public DbSet<BudgetModelsTest> BudgetModelsTest { get; set; } = default!;
        //public DbSet<BudgetRegisterEntryHeaders> BudgetRegisterEntryHeaders { get; set; } = default!;
        //public DbSet<BudgetRegisterEntryHeadersTest> BudgetRegisterEntryHeadersTest { get; set; } = default!;
        //public DbSet<BudgetRegisterEntryLines> BudgetRegisterEntryLines { get; set; } = default!;
        //public DbSet<BudgetRegisterEntryLinesTest> BudgetRegisterEntryLinesTest { get; set; } = default!;
        //public DbSet<CustomerItems> CustomerItems { get; set; } = default!;
        //public DbSet<CustomerItemsTest> CustomerItemsTest { get; set; } = default!;
        //public DbSet<CustInvoiceJour> CustInvoiceJour { get; set; } = default!;
        //public DbSet<CustInvoiceJourTest> CustInvoiceJourTest { get; set; } = default!;

        ////public DbSet<HGMRPCalculations> HGMRPCalculations { get; set; } = default!;
        ////public DbSet<HGMRPCalculationsTest> HGMRPCalculationsTest { get; set; } = default!;
        ////public DbSet<HGMRPDiscountCalculations> HGMRPDiscountCalculations { get; set; } = default!;
        ////public DbSet<HGMRPDiscountCalculationsTest> HGMRPDiscountCalculationsTest { get; set; } = default!;
        ////public DbSet<HGMRPDiscountMasters> HGMRPDiscountMasters { get; set; } = default!;
        ////public DbSet<HGMRPDiscountMastersTest> HGMRPDiscountMastersTest { get; set; } = default!;
        ////public DbSet<HGMRPMasters> HGMRPMasters { get; set; } = default!;
        ////public DbSet<HGMRPMastersTest> HGMRPMastersTest { get; set; } = default!;
        //public DbSet<HSNCodes> HSNCodes { get; set; } = default!;
        //public DbSet<HSNCodesTest> HSNCodesTest { get; set; } = default!;
        //public DbSet<LineDiscountCustomerGroups> LineDiscountCustomerGroups { get; set; } = default!;
        //public DbSet<LineDiscountCustomerGroupsTest> LineDiscountCustomerGroupsTest { get; set; } = default!;
        //public DbSet<PriceCustomerGroups> PriceCustomerGroups { get; set; } = default!;
        //public DbSet<PriceCustomerGroupsTest> PriceCustomerGroupsTest { get; set; } = default!;
        //public DbSet<ProductTranslations> ProductTranslations { get; set; } = default!;
        //public DbSet<ProductTranslationsTest> ProductTranslationsTest { get; set; } = default!;
        //public DbSet<SubledgerVoucherGeneralJournalEntryEntities> SubledgerVoucherGeneralJournalEntryEntities { get; set; } = default!;
        //public DbSet<SubledgerVoucherGeneralJournalEntryEntitiesTest> SubledgerVoucherGeneralJournalEntryEntitiesTest { get; set; } = default!;
        //public DbSet<TaxDocuments> TaxDocuments { get; set; } = default!;
        //public DbSet<TaxDocumentsTest> TaxDocumentsTest { get; set; } = default!;
        //public DbSet<UnitOfMeasureConversions> UnitOfMeasureConversions { get; set; } = default!;
        //public DbSet<UnitOfMeasureConversionsTest> UnitOfMeasureConversionsTest { get; set; } = default!;
        //public DbSet<UnitsOfMeasure> UnitsOfMeasure { get; set; } = default!;
        //public DbSet<UnitsOfMeasureTest> UnitsOfMeasureTest { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            IEnumerable<Type> entityTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.GetCustomAttributes<PrimaryKeyAttribute>().Any());

            foreach (Type entityType in entityTypes)
            {
                if (entityType.FullName.Contains("Base", StringComparison.InvariantCultureIgnoreCase)) continue;

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

        private void AddDbSets()
        {
            var entityTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && !t.IsSubclassOf(typeof(DbContext)));

            foreach (var entityType in entityTypes)
            {
                // Create a DbSet property for each entity type
                PropertyInfo dbSetProperty = typeof(DbContext).GetProperty(nameof(DbSet<object>));

                // Create a generic DbSet<> property
                //var dbSetGeneric = dbSetProperty?.MakeGenericMethod(entityType);

                //// Use reflection to create the DbSet instance
                //var dbSetInstance = dbSetGeneric?.Invoke(this, new object[] { });

                //// Add the DbSet to the context
                //var property = GetType().GetProperties()
                //    .FirstOrDefault(p => p.PropertyType.IsGenericType &&
                //                          p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                //                          p.PropertyType.GetGenericArguments().First() == entityType);

                //property?.SetValue(this, dbSetInstance);
            }
        }
    }
}