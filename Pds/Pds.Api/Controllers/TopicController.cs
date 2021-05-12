using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pds.Api.Authentication;
using Pds.Api.Contracts.Person;
using Pds.Api.Contracts.Topic;
using Pds.Data.Entities;
using Pds.Services.Interfaces;

namespace Pds.Api.Controllers
{
    [ApiController]
    [Route("api/topics")]
    [CustomAuthorize]
    public class TopicController : ApiControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITopicService topicService;

        public TopicController(ITopicService topicService, IMapper mapper)
        {
            this.topicService = topicService;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateTopicResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateTopicAsync(CreateTopicRequest request)
        {
            try
            {
                var mappedTopic = mapper.Map<Topic>(request);
                var result = await topicService.CreateAsync(mappedTopic);
                return Ok(new CreateTopicResponse(result));
            }
            catch (Exception exception)
            {
                return ExceptionResult(exception);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateTopicResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateTopicAsync([FromRoute] Guid id, UpdateTopicRequest request)
        {
            try
            {
                var topic = await topicService.FindByIdAsync(id);
                var mappedTopic = mapper.Map(request, topic);
                var result = await topicService.UpdateAsync(mappedTopic);
                return Ok(new UpdateTopicResponse(result));
            }
            catch (Exception exception)
            {
                return ExceptionResult(exception);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetTopicsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetTopicsRequest request)
        {
            try
            {
                var topics = await topicService.GetAllAsync();
                var response = new GetTopicsResponse
                {
                    Items = mapper.Map<List<TopicDto>>(topics),
                    Total = topics.Count
                };

                return Ok(response);
            }
            catch (Exception exception)
            {
                return ExceptionResult(exception);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetTopicResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindByIdAsync([FromRoute] Guid id)
        {
            try
            {
                var result = await topicService.FindByIdAsync(id);
                var response = mapper.Map<GetTopicResponse>(result);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return ExceptionResult(exception);
            }
        }

        [HttpPost("archive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ArchiveAsync([FromBody] Guid id)
        {
            try
            {
                _ = await topicService.ArchiveAsync(id);
                return Ok();
            }
            catch (Exception exception)
            {
                return ExceptionResult(exception);
            }
        }

        [HttpPost("unarchive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UnarchiveAsync([FromBody] Guid id)
        {
            try
            {
                _ = await topicService.UnarchiveAsync(id);
                return Ok();
            }
            catch (Exception exception)
            {
                return ExceptionResult(exception);
            }
        }
    }
}