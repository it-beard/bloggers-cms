using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pds.Api.Contracts.Client;
using Pds.Data.Entities;
using Pds.Services.Interfaces;

namespace Pds.Api.Controllers
{
    [Route("api/clients")]
    [Authorize]
    public class ClientController : ApiControllerBase
    {
        private readonly ILogger<ClientController> logger;
        private readonly IMapper mapper;
        private readonly IClientService clientService;

        public ClientController(
            ILogger<ClientController> logger,
            IMapper mapper,
            IClientService clientService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.clientService = clientService;
        }

        /// <summary>
        /// Return list of clients
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetClientsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] GetClientsRequest request)
        {
            try
            {
                var clients = await clientService.GetAllAsync();

                var response = new GetClientsResponse
                {
                    Items = mapper.Map<List<ClientDto>>(clients),
                    Total = clients.Count
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Create a client
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateClientResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateClientRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newClient = mapper.Map<Client>(request);
                    var clientId = await clientService.CreateAsync(newClient);
                    return Ok(new CreateClientResponse{Id = clientId});
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Delete specified client
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [HttpDelete("{clientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid clientId)
        {
            try
            {
                await clientService.DeleteAsync(clientId);
                return Ok();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}