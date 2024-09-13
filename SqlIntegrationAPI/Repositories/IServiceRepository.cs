using SqlIntegrationAPI.Models.Domains;

namespace SqlIntegrationAPI.Repositories
{
    public interface IServiceRepository
    {
        public Task<List<DbService>> GetAllAsync();

        public Task<List<DbService>> GetFileteredAsync(string filter);

        public Task<int> CreateAsync(DbService service);

        public Task<DbService> UpdateAsync(string EndPoint, DbService service, long recId = 0);

        public Task<DbService> DeleteAsync(string EndPoint, long recId = 0);
    }
}
