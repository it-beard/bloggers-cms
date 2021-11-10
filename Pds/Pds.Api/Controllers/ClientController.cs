using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pds.Api.Authentication;
using Pds.Api.Contracts.Client;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Client;
namespace Pds.Api.Controllers;

[Route("api/clients")]
[CustomAuthorize]
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

    /// <summary>
    /// Get client by id
    /// </summary>
    /// <param name="clientId"></param>
    /// <returns></returns>
    [HttpGet("{clientId}")]
    [ProducesResponseType(typeof(GetClientResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetClient(Guid clientId)
    {
        try
        {
            var client = await clientService.GetAsync(clientId);
            var response = mapper.Map<GetClientResponse>(client);

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Edit client
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(typeof(EditClientResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Edit(EditClientRequest request)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var editClientModel = mapper.Map<EditClientModel>(request);
                var clientId = await clientService.EditAsync(editClientModel);
                return Ok(new EditClientResponse{Id = clientId});
            }

            return BadRequest();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
}