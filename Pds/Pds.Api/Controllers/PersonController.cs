using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pds.Api.Contracts;
using Pds.Services.Interfaces;

namespace Pds.Api.Controllers
{
    [ApiController]
    [Route("persons")]
    [Authorize]
    public class PersonController : ApiControllerBase
    {
        private readonly ILogger<PersonController> logger;
        private readonly IPersonService personService;

        public PersonController(
            ILogger<PersonController> logger,
            IPersonService personService)
        {
            this.logger = logger;
            this.personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var persons = await personService.GetAllAsync();
                return Ok(persons);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}