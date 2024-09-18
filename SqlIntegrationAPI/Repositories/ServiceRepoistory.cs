using SqlIntegrationAPI.Models.Domains;
using Microsoft.EntityFrameworkCore;
using SqlIntegrationAPI.Data;

namespace SqlIntegrationAPI.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ErpSqlDbContext _context;

        public ServiceRepository(ErpSqlDbContext dbContext)
        {
            _context = dbContext;
            _context.Database.EnsureCreated();
        }

        /// <summary>
        /// Retrieves all DbService entities from the database.
        /// </summary>
        public async Task<List<DbService>> GetAllAsync(string? sortBy = Emp, string? filterOn = Emp, string? filterQuery = Emp, bool ascending = true, int pageNo = 1, int pageSize = 100)
        {
            //throw new Exception("Hi");
            var services = await _context.Services.AsNoTracking().ToListAsync();
            if (!IsEmpty(filterOn) && !IsEmpty(filterQuery))
            {
                services = services.Where(x => x.Name.Contains(filterQuery)).ToList();
            }
            services = ascending ? [.. services.OrderBy(s => s.Name)] : [.. services.OrderByDescending(s => s.Name)];

            int skipRows = (pageNo - 1) * pageSize;
            services = [.. services.Skip(skipRows)];
            return services;
        }

        /// <summary>
        /// Retrieves DbService entities that match the specified filter.
        /// </summary>
        public async Task<List<DbService>> GetByEndpointAsync(string endpoint)
        {
            if (IsEmpty(endpoint))
                return await GetAllAsync();

            // Use Contains for filter matching (case-insensitive if required)
            return await _context.Services.AsNoTracking().Where(s => s.Endpoint.Equals(endpoint)).ToListAsync();
        }

        /// <summary>
        /// Creates a new DbService entity in the database.
        /// </summary>
        public async Task<DbService?> CreateAsync(DbService service)
        {
            DbService result = null;
            string? endPoint = service.Endpoint;
            if (service == null)
                throw new ArgumentNullException(nameof(service), "Service cannot be null.");

            if (IsEmpty(endPoint))
                throw new ArgumentException("Service's Endpoint is required!");

            var existingEntity = await _context.Services.AsNoTracking().FirstOrDefaultAsync(s => s.Endpoint.Equals(endPoint));

            if (existingEntity is not null) throw new Exception("Given service already exists!");
;            // Ensure the service is not already in the local context (check against Endpoint)
            if (!_context.Services.Local.Any(s => s.Endpoint == service.Endpoint))
            {
                var entityCln = await _context.Services.AddAsync(service);
                result = entityCln.Entity;
            }
            await _context.SaveChangesAsync();
            // Save changes and return the result
            return result;
        }

        /// <summary>
        /// Updates an existing DbService entity based on the provided endpoint.
        /// </summary>
        public async Task<DbService?> UpdateAsync(string endPoint, DbService service)
        {
            if (IsEmpty(endPoint)) throw new ArgumentException("Endpoint is required!");

            if (service == null) throw new ArgumentException("Service is required!");

            // Find the existing entity by endpoint
            var existingEntity = await _context.Services.FirstOrDefaultAsync(s => s.Endpoint.Equals(endPoint));
            if (existingEntity == null) return null;

            foreach (var property in typeof(DbService).GetProperties())
            {
                var newValue = property.GetValue(service);
                if (newValue != null && !property.Name.Equals(nameof(DbService.RecId), StrComp) && !property.Name.Equals(nameof(DbService.Endpoint), StrComp)) // Exclude key properties like RecId
                {
                    // Update the value of the property in the existing entity
                    property.SetValue(existingEntity, newValue);
                    _context.Entry(existingEntity).Property(property.Name).IsModified = true;
                }
            }

            // Save changes and return the updated entity
            await _context.SaveChangesAsync();

            return existingEntity;
        }

        /// <summary>
        /// Deletes a DbService entity based on the provided endpoint.
        /// </summary>
        public async Task<DbService?> DeleteAsync(string endPoint)
        {
            if (IsEmpty(endPoint))
                throw new ArgumentException("Endpoint is required!");

            // Find the existing entity by endpoint
            var existingEntity = await _context.Services
                .FirstOrDefaultAsync(s => s.Endpoint.Equals(endPoint));

            if (existingEntity is null)
                return null;

            // Remove the entity
            _context.Services.Remove(existingEntity);
            await _context.SaveChangesAsync();
            // Save changes and return the result
            return existingEntity;
        }

        public async Task<bool> ExistsAsync(string endPoint)
        {
            if (IsEmpty(endPoint))
                throw new ArgumentException("Endpoint is required!");

            return await _context.Services.AnyAsync(e => e.Endpoint == endPoint);
        }
    }
}
