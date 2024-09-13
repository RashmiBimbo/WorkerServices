using Microsoft.AspNetCore.Mvc;
using SqlIntegrationAPI.Data;
using SqlIntegrationAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SqlIntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesControllerAPI : ControllerBase
    {
        private readonly ErpSqlDbContext dbContext;

        public IServiceRepository ServiceRepository { get; }

        public ServicesControllerAPI(ErpSqlDbContext dbContext, IServiceRepository serviceRepository)
        {
            this.dbContext = dbContext;
            ServiceRepository = serviceRepository;
        }

        // GET: api/<ServicesControllerAPI>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ServicesControllerAPI>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ServicesControllerAPI>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ServicesControllerAPI>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServicesControllerAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
