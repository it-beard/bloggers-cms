using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pds.Api.Contracts.Topic;
using Pds.Data.Entities;
using Pds.Services.Interfaces;

namespace Pds.Api.Controllers
{
    [ApiController]
    [Route("api/topics")]
    public class TopicController : ApiControllerBase
    {
        private readonly ITopicService topicService;
        private readonly IMapper mapper;

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

        [HttpGet]
        [ProducesResponseType(typeof(GetTopicsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTopics()
        {
            try
            {
                var result = await topicService.GetAllAsync();
                var topicDtos = mapper.Map<IReadOnlyList<GetTopicDto>>(result);
                return Ok(new GetTopicsResponse(topicDtos, topicDtos.Count));
            }
            catch (Exception exception)
            {
                return ExceptionResult(exception);
            }
        }
    }
}