using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pds.Api.Contracts.Content;
using Pds.Services.Interfaces;

namespace Pds.Api.Controllers
{
    [Route("api/content")]
    [Authorize]
    public class ContentController : ApiControllerBase
    {
        private readonly ILogger<PersonController> logger;
        private readonly IMapper mapper;
        private readonly IContentService contentService;
        private readonly IChannelService channelService;
        private readonly IPersonService personService;
        private readonly IClientService clientService;

        public ContentController(
            ILogger<PersonController> logger,
            IMapper mapper,
            IContentService contentService,
            IChannelService channelService,
            IPersonService personService,
            IClientService clientService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.contentService = contentService;
            this.channelService = channelService;
            this.personService = personService;
            this.clientService = clientService;
        }

        /// <summary>
        /// Return all content
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetContentResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var content = await contentService.GetAllAsync();
                var response = new GetContentResponse
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
        /// Return list of channels for checkboxes group
        /// </summary>
        [HttpGet]
        [Route("get-channels")]
        public async Task<IActionResult> GetListOfChannels()
        {
            try
            {
                var channels = await channelService.GetChannelsForListsAsync();
                var response = mapper.Map<List<ChannelForRadioboxGroupDto>>(channels);

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
        public async Task<IActionResult> Create(CreateContentRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}