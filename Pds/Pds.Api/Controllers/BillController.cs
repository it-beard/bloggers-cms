using Pds.Api.Contracts.Controllers;
using Pds.Api.Contracts.Controllers.Bill;
using Pds.Api.Contracts.Controllers.Bill.CreateBill;
using Pds.Api.Contracts.Controllers.Bill.EditBill;
using Pds.Api.Contracts.Controllers.Bill.GetBill;
using Pds.Api.Contracts.Controllers.Bill.GetBills;
using Pds.Api.Contracts.Controllers.Bill.PayBill;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Bill;
namespace Pds.Api.Controllers;

[Route("api/bills")]
public class BillController : ApiControllerBase
{
    private readonly ILogger<PersonController> logger;
    private readonly IMapper mapper;
    private readonly IBillService billService;
    private readonly IBrandService brandService;
    private readonly IClientService clientService;

    public BillController(
        ILogger<PersonController> logger,
        IMapper mapper,
        IBillService billService,
        IBrandService brandService,
        IClientService clientService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.billService = billService;
        this.brandService = brandService;
        this.clientService = clientService;
    }
        
    /// <summary>
    /// Pay bill
    /// </summary>
    /// <returns></returns>
    [HttpPut("{billId}/pay")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> PayBill(Guid billId, PayBillPayload payload)
    {
        try
        {
            var model = new PayBillModel
            {
                BillId = billId,
                Value = payload.Value,
                Comment = payload.Comment,
                PaymentType = payload.PaymentType,
                PaidAt = payload.PaidAt,
                IsNeedPayNds = payload.IsNeedPayNds,
                ContractDate = payload.ContractDate,
                ContractNumber = payload.ContractNumber
            };
            await billService.PayBillAsync(model);
                
            return Ok();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
        
    /// <summary>
    /// Get bill by id
    /// </summary>
    /// <param name="billId"></param>
    /// <returns></returns>
    [HttpGet("{billId}")]
    [ProducesResponseType(typeof(GetBillResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(Guid billId)
    {
        try
        {
            var bill = await billService.GetAsync(billId);
            var response = mapper.Map<GetBillResponse>(bill);

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Return list of bills
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("paid")]
    [ProducesResponseType(typeof(GetBillsResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllPaid([FromQuery] GetBillsRequest request)
    {
        try
        {
            var paidBills = await billService.GetAllPaidAsync();

            var response = new GetBillsResponse
            {
                Items = mapper.Map<List<GetBillsBillDto>>(paidBills),
                Total = paidBills.Count
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
            var brands = await brandService.GetAllForListsAsync();
            var response = mapper.Map<List<BrandDto>>(brands);

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
            var clients = await clientService.GetForListsAsync();
            var response = mapper.Map<List<ClientForLookupDto>>(clients);

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
    
    /// <summary>
    /// Return list of clients with selected content client for lookup box
    /// </summary>
    /// <param name="contentClientId"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("get-clients/clients/{contentClientId?}")]
    public async Task<IActionResult> GetClientsWithContentClient(Guid? contentClientId)
    {
        try
        {
            var clients = await clientService.GetForListWithSelectedValueAsync(contentClientId);
            var response = mapper.Map<List<ClientForLookupDto>>(clients);

            return Ok(response);
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Add bill
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateBillResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateBillRequest request)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var newBill = mapper.Map<Bill>(request);
                var billId = await billService.CreateAsync(newBill);
                return Ok(new CreateBillResponse{Id = billId});
            }

            return BadRequest();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Edit bill
    /// </summary>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(typeof(EditBillResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Edit(EditBillRequest request)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest();
            var editBillModel = mapper.Map<EditBillModel>(request);
            var billId = await billService.EditAsync(editBillModel);
            return Ok(new EditBillResponse{Id = billId});

        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Archive specified bill
    /// </summary>
    /// <param name="billId"></param>
    /// <returns></returns>
    [HttpPut("{billId}/archive")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Archive(Guid billId)
    {
        try
        {
            await billService.ArchiveAsync(billId);
            return Ok();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Unarchive specified bill
    /// </summary>
    /// <param name="billId"></param>
    /// <returns></returns>
    [HttpPut("{billId}/unarchive")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Unarchive(Guid billId)
    {
        try
        {
            await billService.UnarchiveAsync(billId);
            return Ok();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }

    /// <summary>
    /// Delete specified bill
    /// </summary>
    /// <param name="billId"></param>
    /// <returns></returns>
    [HttpDelete("{billId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid billId)
    {
        try
        {
            await billService.DeleteAsync(billId);
            return Ok();
        }
        catch (Exception e)
        {
            return ExceptionResult(e);
        }
    }
}