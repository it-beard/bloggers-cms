using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pds.Api.Authentication;
using Pds.Api.Contracts.Person;
using Pds.Data.Entities;
using Pds.Data.QueryCreators.Settings;
using Pds.Services.Interfaces;
using PersonsFieldName = Pds.Data.QueryCreators.Settings.PersonsFieldName;

namespace Pds.Api.Controllers
{
    [Route("api/persons")]
    [CustomAuthorize]
    public class PersonController : ApiControllerBase
    {
        private readonly ILogger<PersonController> logger;
        private readonly IMapper mapper;
        private readonly IPersonService personService;
        private readonly IBrandService brandService;

        public PersonController(
            ILogger<PersonController> logger,
            IMapper mapper,
            IPersonService personService,
            IBrandService brandService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.personService = personService;
            this.brandService = brandService;
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



        ///// <summary>
        ///// Return list of persons
        ///// </summary>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //[HttpPost("search")]
        //[ProducesResponseType(typeof(GetPersonsResponse), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAll([FromBody] GetPersonsRequest request)
        //{
        //    try
        //    {
        //        var searchSettings = mapper.Map<GetPersonsRequest, SearchSettings<PersonsFieldName>>(request);

        //        var result = await personService.GetPagedAsync(searchSettings);

        //        var response = new GetPersonsResponse
        //        {
        //            Items = mapper.Map<PersonDto[]>(result.people),
        //            Total = result.total
        //        };

        //        return Ok(response);
        //    }
        //    catch (Exception e)
        //    {
        //        return ExceptionResult(e);
        //    }
        //}

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
                    return Ok(new CreatePersonResponse{Id = personId});
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
        /// Return list of brands for checkboxes group.
        /// </summary>
        [HttpGet]
        [Route("get-brands")]
        public async Task<IActionResult> GetListOfBrands()
        {
            try
            {
                var brands = await brandService.GetBrandsForListsAsync();
                var response = mapper.Map<List<BrandForCheckboxesDto>>(brands);

                return Ok(response);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}