using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pds.Api.Authentication;
using Pds.Api.Contracts.Content;
using Pds.Services.Interfaces;
using Pds.Services.Models;
using Pds.Services.Models.Content;

namespace Pds.Api.Controllers
{
    [Route("api/content")]
    [CustomAuthorize]
    public class ContentController : ApiControllerBase
    {
        private readonly ILogger<PersonController> logger;
        private readonly IMapper mapper;
        private readonly IContentService contentService;
        private readonly IBrandService brandService;
        private readonly IPersonService personService;
        private readonly IClientService clientService;

        public ContentController(
            ILogger<PersonController> logger,
            IMapper mapper,
            IContentService contentService,
            IBrandService brandService,
            IPersonService personService,
            IClientService clientService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.contentService = contentService;
            this.brandService = brandService;
            this.personService = personService;
            this.clientService = clientService;
        }

        /// <summary>
        /// Return all content
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetContentsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var content = await contentService.GetAllAsync();
                var response = new GetContentsResponse
                {
                    Items = mapper.Map<List<ContentDto>>(content),
                    Total = content.Count
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Return list of brands for checkboxes group
        /// </summary>
        [HttpGet]
        [Route("get-brands")]
        public async Task<IActionResult> GetListOfBrands()
        {
            try
            {
                var brands = await brandService.GetBrandsForListsAsync();
                var response = mapper.Map<List<BrandForRadioboxGroupDto>>(brands);

                return Ok(response);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
        
        /// <summary>
        /// Return list of persons for lookup box
        /// </summary>
        [HttpGet]
        [Route("get-persons")]
        public async Task<IActionResult> GetListOfPersons()
        {
            try
            {
                var persons = await personService.GetPersonsForListsAsync();
                var response = mapper.Map<List<PersonForLookupDto>>(persons);

                return Ok(response);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
        
        /// <summary>
        /// Return list of clients for lookup box
        /// </summary>
        [HttpGet]
        [Route("get-clients")]
        public async Task<IActionResult> GetListOfClients()
        {
            try
            {
                var clients = await clientService.GetClientsForListsAsync();
                var response = mapper.Map<List<ClientForLookupDto>>(clients);

                return Ok(response);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Create content and bill
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateContentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateContentRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createContentModel = mapper.Map<CreateContentModel>(request);
                    var clientId = await contentService.CreateAsync(createContentModel);
                    return Ok(new CreateContentResponse{Id = clientId});
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Edit content
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(EditContentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(EditContentRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var editContentModel = mapper.Map<EditContentModel>(request);
                    var clientId = await contentService.EditAsync(editContentModel);
                    return Ok(new EditContentResponse{Id = clientId});
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Get content for pay by id
        /// </summary>
        /// <param name="contentId"></param>
        /// <returns></returns>
        [HttpGet("{contentId}/pay")]
        [ProducesResponseType(typeof(GetContentForPayResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContentForPay(Guid contentId)
        {
            try
            {
                var content = await contentService.GetAsync(contentId);
                var response = mapper.Map<GetContentForPayResponse>(content);

                return Ok(response);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Get content by id
        /// </summary>
        /// <param name="contentId"></param>
        /// <returns></returns>
        [HttpGet("{contentId}")]
        [ProducesResponseType(typeof(GetContentResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContent(Guid contentId)
        {
            try
            {
                var content = await contentService.GetAsync(contentId);
                var response = mapper.Map<GetContentResponse>(content);

                return Ok(response);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Delete specified content
        /// </summary>
        /// <param name="contentId"></param>
        /// <returns></returns>
        [HttpDelete("{contentId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid contentId)
        {
            try
            {
                await contentService.DeleteAsync(contentId);
                return Ok();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Archive specified content
        /// </summary>
        /// <param name="contentId"></param>
        /// <returns></returns>
        [HttpPut("{contentId}/archive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Archive(Guid contentId)
        {
            try
            {
                await contentService.ArchiveAsync(contentId);
                return Ok();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}