using IncidentProject.Interfaces;
using IncidentProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IncidentProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] MainRequestModel requestModel)
        {
            try
            {
                if (!_contactService.Validate(requestModel, out var errorMessage))
                {
                    return UnprocessableEntity(errorMessage);
                }

                var newContact = _contactService.CreateContact(requestModel);

                return Ok(new {
                    newContact.Email,
                    newContact.FirstName,
                    newContact.LastName
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
