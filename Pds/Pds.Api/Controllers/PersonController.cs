using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pds.Api.Contracts.Person;
using Pds.Data.Entities;
using Pds.Services.Interfaces;

namespace Pds.Api.Controllers
{
    [Route("api/persons")]
    [Authorize]
    public class PersonController : ApiControllerBase
    {
        private readonly ILogger<PersonController> logger;
        private readonly IMapper mapper;
        private readonly IPersonService personService;
        private readonly IChannelService channelService;

        public PersonController(
            ILogger<PersonController> logger,
            IMapper mapper,
            IPersonService personService,
            IChannelService channelService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.personService = personService;
            this.channelService = channelService;
        }

        /// <summary>
        /// Return list of persons
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetPersonsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetPersonsRequest request)
        {
            try
            {
                var persons = await personService.GetAllAsync();

                var response = new GetPersonsResponse
                {
                    Items = mapper.Map<List<PersonDto>>(persons),
                    Total = persons.Count
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
        /// Update information about specified person
        /// </summary>
        /// <returns></returns>
        [HttpPut("personId:guid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(Guid personId, UpdatePersonRequest request)
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
        /// Delete specified person
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpDelete("{personId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid personId)
        {
            try
            {
                await personService.DeleteAsync(personId);
                return Ok();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Archive specified person
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpPut("{personId}/archive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Archive(Guid personId)
        {
            try
            {
                await personService.ArchiveAsync(personId);
                return Ok();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Unarchive specified person
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        [HttpPut("{personId}/unarchive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Unarchive(Guid personId)
        {
            try
            {
                await personService.UnarchiveAsync(personId);
                return Ok();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Return list of channels for checkboxes group.
        /// </summary>
        [HttpGet]
        [Route("get-channels")]
        public async Task<IActionResult> GetListOfChannels()
        {
            try
            {
                var channels = await channelService.GetChannelsForListsAsync();
                var response = mapper.Map<List<ChannelDto>>(channels);

                return Ok(response);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}