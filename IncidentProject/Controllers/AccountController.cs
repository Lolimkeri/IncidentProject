using IncidentProject.Interfaces;
using IncidentProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IncidentProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Create([FromBody] MainRequestModel requestModel)
        {
            try
            {
                if (!_accountService.Validate(requestModel, out var errorMessage))
                {
                    return UnprocessableEntity(errorMessage);
                }

                var newAccount = _accountService.CreateAccount(requestModel);

                return Ok(new
                {
                    newAccount.Name
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
