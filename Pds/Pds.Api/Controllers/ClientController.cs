using Pds.Api.Contracts.Controllers.Client.CreateClient;
using Pds.Api.Contracts.Controllers.Client.EditClient;
using Pds.Api.Contracts.Controllers.Client.GetClient;
using Pds.Api.Contracts.Controllers.Client.GetClients;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Client;
namespace Pds.Api.Controllers;

[Route("api/clients")]
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
                Items = mapper.Map<List<GetClientsClientDto>>(clients),
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
    /// Archive specified client
    /// </summary>
    /// <param name="clientId"></param>
    /// <returns></returns>
    [HttpPut("{clientId}/archive")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Archive(Guid clientId)
    {
        try
        {
            await clientService.ArchiveAsync(clientId);
            return Ok();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Unarchive specified client
    /// </summary>
    /// <param name="clientId"></param>
    /// <returns></returns>
    [HttpPut("{clientId}/unarchive")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Unarchive(Guid clientId)
    {
        try
        {
            await clientService.UnarchiveAsync(clientId);
            return Ok();
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
    public async Task<IActionResult> Get(Guid clientId)
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