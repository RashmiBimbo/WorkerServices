using SqlIntegrationAPI.Models.Domains;
using CommonCode.CommonClasses;
using static CommonCode.CommonClasses.Common;


namespace SqlIntegrationAPI.Repositories
{
    public interface IServiceRepository
    {
        public Task<List<DbService>?> GetAllAsync(string? sortBy=Emp, string? filterOn = Emp, string? filterQuery = Emp, bool ascending = true, int pageNo = 1, int pageSize = 100);

        public Task<List<DbService>?> GetByEndpointAsync(string endpoint);

        public Task<DbService?> CreateAsync(DbService service);

        public Task<DbService?> UpdateAsync(string endPoint, DbService service);

        public Task<DbService?> DeleteAsync(string endPoint);

        public Task<bool> ExistsAsync(string endPoint);
    }
}
