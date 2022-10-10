using IncidentProject.Exceptions;
using IncidentProject.Interfaces;
using IncidentProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IncidentProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] MainRequestModel requestModel)
        {
            try
            {
                if (!_incidentService.Validate(requestModel, out var errorMessage))
                {
                    return UnprocessableEntity(errorMessage);
                }

                var newIncident = _incidentService.CreateIncident(requestModel);

                return Ok(new
                {
                    newIncident.Name,
                    newIncident.Description
                });
            }
            catch(AccountBadNameException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
