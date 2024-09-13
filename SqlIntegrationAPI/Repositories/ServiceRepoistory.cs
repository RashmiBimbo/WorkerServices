using Microsoft.EntityFrameworkCore;
using SqlIntegrationAPI.Data;
using SqlIntegrationAPI.Models.Domains;
using System.Collections.Generic;

namespace SqlIntegrationAPI.Repositories
{
    public class ServiceRepoistory : IServiceRepository
    {
        public ErpSqlDbContext Cntxt { get; }

        public ServiceRepoistory(ErpSqlDbContext dbContext)
        {
            Cntxt = dbContext;
            Cntxt.Database.EnsureCreated();
        }

        public async Task<int> CreateAsync(DbService service)
        {
            if (service is null) throw new ArgumentNullException(nameof(service));
            if (IsEmpty(service.Endpoint)) throw new ArgumentException($"{service}'s Endpoint is required!");

            await Cntxt.AddAsync(service);
            return await Cntxt.SaveChangesAsync();
        }

        public async Task<DbService> DeleteAsync(string endPoint, DbService service)
        {
            if (IsEmpty(endPoint)) throw new ArgumentException($"Endpoint is required!");
            if (service is null) throw new ArgumentException($"Service is required!");

            DbService? existingEntity = Cntxt.Services.AsNoTracking()?.FirstOrDefault(s => s.Endpoint.Equals(endPoint, StrComp));
            existingEntity.Active = false;
            Cntxt.Entry(existingEntity)?.CurrentValues.SetValues(existingEntity);
            return service;
        }

        public async Task<List<DbService>> GetAllAsync()
        {
            return await Cntxt.Services.ToListAsync();
        }

        public async Task<List<DbService>> GetFileteredAsync(string filter)
        {
            if (IsEmpty(filter)) return await Cntxt.Services.ToListAsync();

            return await Cntxt.Services.Where(s => s.Name.Contains(filter, StrComp)).ToListAsync();
        }

        public async Task<DbService> UpdateAsync(string endPoint, DbService service, long recId = 0)
        {
            if (IsEmpty(endPoint)) throw new ArgumentException($"Endpoint is required!");
            if (service is null) throw new ArgumentException($"Service is required!");
            DbService? existingEntity = Cntxt.Services.AsNoTracking()?.FirstOrDefault(s => s.Endpoint.Equals(endPoint, StrComp));
            Cntxt.Entry(existingEntity)?.CurrentValues.SetValues(service);
            return service;
        }

        public Task<DbService> DeleteAsync(string EndPoint, long recId = 0)
        {
            throw new NotImplementedException();
        }
    }
}
