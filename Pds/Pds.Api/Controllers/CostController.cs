using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pds.Api.Authentication;
using Pds.Api.Contracts.Cost;
using Pds.Services.Interfaces;

namespace Pds.Api.Controllers
{
    [Route("api/costs")]
    [CustomAuthorize]
    public class CostController : ApiControllerBase
    {
        private readonly ILogger<PersonController> logger;
        private readonly IMapper mapper;
        private readonly ICostService costService;

        public CostController(
            ILogger<PersonController> logger,
            IMapper mapper,
            ICostService costService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.costService = costService;
        }

        /// <summary>
        /// Return list of costs
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetCostsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetCostsRequest request)
        {
            try
            {
                var costs = await costService.GetAllAsync();

                var response = new GetCostsResponse
                {
                    Items = mapper.Map<List<CostDto>>(costs),
                    Total = costs.Count
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}