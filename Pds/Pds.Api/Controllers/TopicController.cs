using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pds.Api.Authentication;
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
        public async Task<IActionResult> CreateTopic(CreateTopicRequest request)
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
        public async Task<IActionResult> UpdateTopic([FromRoute] Guid id, UpdateTopicRequest request)
        {
            try
            {
                var topic = await topicService.FindById(id);
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
        [ProducesResponseType(typeof(GetTopicCollectionResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTopics()
        {
            try
            {
                var result = await topicService.GetAllAsync();
                var topics = mapper.Map<IReadOnlyList<GetTopicDto>>(result);
                return Ok(new GetTopicCollectionResponse(topics));
            }
            catch (Exception exception)
            {
                return ExceptionResult(exception);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetTopicDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindById([FromRoute] Guid id)
        {
            try
            {
                var result = await topicService.FindById(id);
                var response = mapper.Map<GetTopicDto>(result);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return ExceptionResult(exception);
            }
        }

        [HttpPost("archive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Archive([FromBody] Guid id)
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
        public async Task<IActionResult> Unarchive([FromBody] Guid id)
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