using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper mapper;
        private readonly IPersonService personService;

        public PersonController(
            ILogger<PersonController> logger,
            IMapper mapper,
            IPersonService personService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var persons = await personService.GetAllAsync();
                var result = mapper.Map<List<PersonContract>>(persons);

                return Ok(result);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}