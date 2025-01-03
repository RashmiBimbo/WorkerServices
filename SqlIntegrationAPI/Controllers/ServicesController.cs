﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SqlIntegrationAPI.Models.Domains;
using CommonCode.Models.Dtos.Requests;
using CommonCode.Models.Dtos.Responses;
using SqlIntegrationAPI.Repositories;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using CommonCode.Models.Dtos;

namespace SqlIntegrationAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    //[Authorize]
    public class ServicesController(IServiceRepository serviceRepository, IMapper mapper, ILogger<ServicesController> logger) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly ILogger<ServicesController> logger = logger;
        private readonly IServiceRepository _serviceRepository = serviceRepository;

        // GET: api/Services
        [HttpGet()]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetServices(string? sortBy, string? filterOn, string? filterQuery, bool ascending = true, int pageNo = 1, int pageSize = 100)
        {
            //logger.LogInformation("GetServices get called");
            //throw new Exception("Hi exception");
            var services = await _serviceRepository.GetAllAsync(sortBy, filterOn, filterQuery, ascending, pageNo, pageSize);
            if (services == null || services.Count == 0)
            {
                return NoContent();
            }
            // Map domain models to DTOs for response
            var serviceDtos = _mapper.Map<List<ServiceDto>>(services);

            return Ok(serviceDtos);
        }

        // GET: api/Services/Diagnostics
        [HttpGet("Diagnostics")]
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

        // GET: api/Services/{endPoint}
        [HttpGet("{endPoint}")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetService([FromRoute] string endPoint)
        {
            var services = await _serviceRepository.GetByEndpointAsync(endPoint);

            if (services == null || services.Count == 0)
            {
                return NotFound("No service with matching endpoint was found!");
            }

            // Map domain models to DTOs for response
            var serviceDtos = _mapper.Map<List<ServiceDto>>(services);
            return Ok(serviceDtos);
        }

        // GET: api/Services/Diagnostics/{endPoint}
        [HttpGet("Diagnostics/{endPoint}")]
        //[Authorize]
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

        // POST: api/Services/Services
        [HttpPost()]
        //[Authorize]
        public async Task<ActionResult> CreateService([FromBody] ServiceDto createService)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await ServiceExists(createService.Endpoint))
            {
                return StatusCode(StatusCodes.Status409Conflict, "Service already exists.");
            }

            var createdEntity = await _serviceRepository.CreateAsync(_mapper.Map<DbService>(createService));

            if (createdEntity is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create the service.");
            }
            return CreatedAtAction(nameof(GetService), new { endPoint = createService.Endpoint }, createService);

            // Return the created entity and its location
            //return CreatedAtAction(nameof(GetService), new { endPoint = createService.Endpoint });
        }

        [HttpPost("PostServices")]
        //[Authorize]
        public async Task<List<ActionResult>> CreateService([FromBody] List<ServiceDto> services)
        {
            List<ActionResult> lst = [];
            foreach (var service in services)
            {
                if (!ModelState.IsValid)
                {
                    lst.Add(BadRequest(ModelState));
                    continue;
                }
                if (await ServiceExists(service.Endpoint))
                {
                    lst.Add(StatusCode(StatusCodes.Status409Conflict, "Service already exists."));
                    continue;
                }

                var createdEntity = await _serviceRepository.CreateAsync(_mapper.Map<DbService>(service));
                if (createdEntity is null)
                    lst.Add(StatusCode(StatusCodes.Status500InternalServerError, "Failed to create the service."));

                lst.Add(CreatedAtAction(nameof(GetService), new { endPoint = service.Endpoint }, service));
            }
            return lst;
        }

        // PUT: api/Services/{endPoint}
        [HttpPut("{endPoint}")]
        //[Authorize]
        public async Task<IActionResult> UpdateService([FromRoute] string endPoint, [FromBody] ServiceDto editService)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return await Update(endPoint, editService);
        }

        // PUT: api/Services/Diagnostics/{endPoint}
        [HttpPut("Diagnostics/{endPoint}")]
        //[Authorize]
        public async Task<IActionResult> UpdateDiagnose(string endPoint, [FromBody] ServiceDto editService)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return await Update(endPoint, editService);
        }

        // DELETE: api/Services/{endPoint}
        [HttpDelete("{endPoint}")]
        //[Authorize]
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

        private async Task<IActionResult> Update(string endPoint, ServiceDto editService)
        {
            if (editService is null || IsEmpty(endPoint))
            {
                return BadRequest("Please provide all the required parameters.");
            }
            //if (!(editService is EditDiagnosRequestDto || editService is PartialServiceDto || editService is ServiceDto))
            //{
            //    return BadRequest("Please provide all the required parameters in correct format.");
            //}
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

            var updatedResult = await _serviceRepository.UpdateAsync(endPoint, _mapper.Map<DbService>(editService));

            if (updatedResult is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update the service.");
            }
            return NoContent(); // Successfully updated, returning no content
        }
    }
}
