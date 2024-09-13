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
        public async Task<List<DbService>> GetAllAsync()
        {
            return await _context.Services.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Retrieves DbService entities that match the specified filter.
        /// </summary>
        public async Task<List<DbService>> GetFileteredAsync(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
                return await GetAllAsync();

            // Use Contains for filter matching (case-insensitive if required)
            return await _context.Services
                .AsNoTracking()
                .Where(s => s.Name.Contains(filter, StrComp))
                .ToListAsync();
        }

        /// <summary>
        /// Creates a new DbService entity in the database.
        /// </summary>
        public async Task<int> CreateAsync(DbService service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service), "Service cannot be null.");

            if (string.IsNullOrWhiteSpace(service.Endpoint))
                throw new ArgumentException("Service's Endpoint is required!");

            // Ensure the service is not already in the local context (check against Endpoint)
            if (!_context.Services.Local.Any(s => s.Endpoint == service.Endpoint))
            {
                await _context.Services.AddAsync(service);
            }

            // Save changes and return the result
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates an existing DbService entity based on the provided endpoint.
        /// </summary>
        public async Task<int> UpdateAsync(string endPoint, DbService service)
        {
            if (IsEmpty(endPoint))
                throw new ArgumentException("Endpoint is required!");

            if (service == null)
                throw new ArgumentException("Service is required!");

            // Find the existing entity by endpoint
            var existingEntity = await _context.Services
                .FirstOrDefaultAsync(s => s.Endpoint.Equals(endPoint, StrComp));

            if (existingEntity == null)
                return 0;

            // Update the existing entity with new values
            _context.Entry(existingEntity).CurrentValues.SetValues(service);

            // Save changes and return the result
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a DbService entity based on the provided endpoint.
        /// </summary>
        public async Task<int> DeleteAsync(string endPoint)
        {
            if (string.IsNullOrWhiteSpace(endPoint))
                throw new ArgumentException("Endpoint is required!");

            // Find the existing entity by endpoint
            var existingEntity = await _context.Services
                .FirstOrDefaultAsync(s => s.Endpoint.Equals(endPoint, StrComp));

            if (existingEntity == null)
                return 0;

            // Remove the entity
            _context.Services.Remove(existingEntity);

            // Save changes and return the result
            return await _context.SaveChangesAsync();
        }
    }
}
