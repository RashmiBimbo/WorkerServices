using SqlIntegrationAPI.Models.Domains;

namespace SqlIntegrationAPI.Repositories
{
    public interface IServiceRepository
    {
        public Task<List<DbService>> GetAllAsync();

        public Task<List<DbService>> GetFileteredAsync(string filter);

        public Task<int> CreateAsync(DbService service);

        public Task<int> UpdateAsync(string EndPoint, DbService service);

        public Task<int> DeleteAsync(string EndPoint);
    }
}
