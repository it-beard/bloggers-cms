using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pds.Api.Contracts.Person;
using Pds.Data.Entities;
using Pds.Data.Repositories;
using Pds.Services.Interfaces;

namespace Pds.Api.Controllers
{
    [Route("api/persons")]
    //[Authorize]
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

        /// <summary>
        /// Return list of persons
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("search")]
        [ProducesResponseType(typeof(GetPersonsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromBody] GetPersonsRequest request)
        {
            try
            {
                var searchSettings = mapper.Map<SearchSettings>(request);

                var result = await personService.GetAsync(searchSettings);

                var response = new GetPersonsResponse
                {
                    Items = mapper.Map<PersonDto[]>(result.people),
                    Total = result.total
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Return details about specified person
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpGet("personId:guid")]
        [ProducesResponseType(typeof(GetPersonDetailsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid personId)
        {
            try
            {
                // var person = await personService.Get(personId);
                // var result = mapper.Map<PersonDetailsContract>(persons);

                return Ok();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Create a person
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreatePersonResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreatePersonRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newPerson = mapper.Map<Person>(request);
                    var personId = await personService.CreateAsync(newPerson);
                    return Ok(personId);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Update information about specified person
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(UpdatePersonRequest request)
        {
            try
            {
                // var person = await personService.Get(personId);
                // var result = mapper.Map<PersonDetailsContract>(persons);

                return Ok();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Create archive info about specified person
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpPost("personId:guid/archive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Archive(Guid personId)
        {
            try
            {
                // var person = await personService.Get(personId);
                // var result = mapper.Map<PersonDetailsContract>(persons);

                return Ok();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Delete archive info about specified person
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpDelete("personId:guid/archive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Unarchive(Guid personId)
        {
            try
            {
                // var person = await personService.Get(personId);
                // var result = mapper.Map<PersonDetailsContract>(persons);

                return Ok();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}