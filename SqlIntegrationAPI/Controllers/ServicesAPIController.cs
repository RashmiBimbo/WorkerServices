using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SqlIntegrationAPI.Models.Domains;
using CommonCode.Models.Dtos.Requests;
using CommonCode.Models.Dtos.Responses;
using SqlIntegrationAPI.Repositories;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace SqlIntegrationAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ServicesAPIController(IServiceRepository serviceRepository, IMapper mapper, ILogger<ServicesAPIController> logger) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<ServicesAPIController> logger = logger;
        private readonly IServiceRepository _serviceRepository = serviceRepository;

        // GET: api/ServicesAPI/Services
        [HttpGet("Services")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GetServiceResponseDto>>> GetServices(string? sortBy, string? filterOn, string? filterQuery, bool ascending = true, int pageNo = 1, int pageSize = 100)
        {
            //logger.LogInformation("GetServices get called");
            //throw new Exception("Hi exception");
            var services = await _serviceRepository.GetAllAsync(sortBy, filterOn, filterQuery, ascending, pageNo, pageSize);
            if (services == null || services.Count == 0)
            {
                return NoContent();
            }
            // Map domain models to DTOs for response
            var serviceDtos = _mapper.Map<List<GetServiceResponseDto>>(services);

            return Ok(serviceDtos);
        }

        // GET: api/ServicesAPI/Diagnostics
        [HttpGet("Diagnostics")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GetDiagnosResponseDto>>> GetDiagnostics(string? sortBy, string? filterQuery, bool ascending = true, int pageNo = 1, int pageSize = 100)
        {
            var services = await _serviceRepository.GetAllAsync(sortBy, Emp, filterQuery, ascending, pageNo, pageSize);
            if (services == null || services.Count == 0)
            {
                return NoContent();
            }
            // Map domain models to DTOs for response
            var serviceDtos = _mapper.Map<List<GetDiagnosResponseDto>>(services);

            return Ok(serviceDtos);
        }

        // GET: api/ServicesAPI/Services/{endPoint}
        [HttpGet("Services/{endPoint}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GetServiceResponseDto>>> GetService(string endPoint)
        {
            var services = await _serviceRepository.GetByEndpointAsync(endPoint);

            if (services == null || services.Count == 0)
            {
                return NotFound("No service with matching endpoint was found!");
            }

            // Map domain models to DTOs for response
            var serviceDtos = _mapper.Map<List<GetServiceResponseDto>>(services);
            return Ok(serviceDtos);
        }

        // GET: api/ServicesAPI/Diagnostics/{endPoint}
        [HttpGet("Diagnostics/{endPoint}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GetDiagnosResponseDto>>> GetDiagnosticsSingle(string endPoint)
        {
            var services = await _serviceRepository.GetByEndpointAsync(endPoint);

            if (services == null || services.Count == 0)
            {
                return NotFound("No service with matching endpoint was found!");
            }

            // Map domain models to DTOs for response
            var serviceDtos = _mapper.Map<List<GetDiagnosResponseDto>>(services);
            return Ok(serviceDtos);
        }

        // POST: api/ServicesAPI/Services
        [HttpPost("Services")]
        [Authorize]
        public async Task<ActionResult> CreateService([FromBody] CreateServiceRequestDto createService)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            createService.CreatedBy = "Rashmi";

            var createdEntity = await _serviceRepository.CreateAsync(_mapper.Map<DbService>(createService));

            if (createdEntity is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create the service.");
            }
            return CreatedAtAction(nameof(GetService), new { endPoint = createService.Endpoint }, createService);

            // Return the created entity and its location
            //return CreatedAtAction(nameof(GetService), new { endPoint = createService.Endpoint });
        }

        // PUT: api/ServicesAPI/Services/{endPoint}
        [HttpPut("Services/{endPoint}")]
        [Authorize]
        public async Task<IActionResult> UpdateService(string endPoint, [FromBody] EditServiceRequestDto editService)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return await Update(endPoint, editService);
        }

        // PUT: api/ServicesAPI/Diagnostics/{endPoint}
        [HttpPut("Diagnostics/{endPoint}")]
        [Authorize]
        public async Task<IActionResult> UpdateDiagnose(string endPoint, [FromBody] EditDiagnosRequestDto editService)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return await Update(endPoint, editService);
        }

        // DELETE: api/ServicesAPI/Services/{endPoint}
        [HttpDelete("Services/{endPoint}")]
        [Authorize]
        public async Task<IActionResult> DeleteService(string endPoint)
        {
            if (IsEmpty(endPoint))
            {
                return BadRequest("Endpoint is required to delete the service.");
            }

            var deletedResult = await _serviceRepository.DeleteAsync(endPoint);

            if (deletedResult is null)
            {
                return NotFound("The service with the given endpoint was not found.");
            }

            return Ok($"Service with endpoint '{endPoint}' was successfully deleted.");
        }

        // Utility method to check if a service exists by endpoint
        private async Task<bool> ServiceExists(string endPoint)
        {
            return await _serviceRepository.ExistsAsync(endPoint);
        }

        private async Task<IActionResult> Update(string endPoint, dynamic editService)
        {
            if (editService is null || IsEmpty(endPoint))
            {
                return BadRequest("Please provide all the required parameters.");
            }
            if (!(editService is EditDiagnosRequestDto || editService is EditServiceRequestDto))
            {
                return BadRequest("Please provide all the required parameters in correct format.");
            }
            if (IsEmpty(editService.Endpoint))
            {
                editService.Endpoint = endPoint;
            }
            else if (endPoint != editService.Endpoint)
                return BadRequest("The provided endpoint does not match the service's endpoint.");

            if (!await ServiceExists(endPoint))
            {
                return NotFound();
            }
            editService.ModifiedBy = "Rashmi";
            editService.ModifiedDate = DateTime.Now;

            var updatedResult = await _serviceRepository.UpdateAsync(endPoint, _mapper.Map<DbService>(editService));

            if (updatedResult is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update the service.");
            }
            return NoContent(); // Successfully updated, returning no content
        }
    }
}
