using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pds.Api.Contracts.Content;
using Pds.Api.Contracts.Person;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;
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

        public ContentController(
            ILogger<PersonController> logger,
            IMapper mapper,
            IContentService contentService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.contentService = contentService;
        }

        /// <summary>
        /// Return all content
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetPersonsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetPersonsRequest request)
        {
            try
            {
                var content = await contentService.GetAllAsync();
                var response = new GetContentResponse
                {
                    Items = mapper.Map<ContentDto[]>(content),
                    Total = content.Count
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpGet]
        [Route("get-channels")]
        public async Task<IActionResult> GetListOfChannels()
        {
            try
            {
                var channels = await contentService.GetChannelsAsync();
                var response = mapper.Map<List<ChannelDto>>(channels);

                return Ok(response);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Create content and bill.
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