using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pds.Api.Authentication;
using Pds.Api.Contracts.Bill;
using Pds.Api.Contracts.Cost;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Bill;

namespace Pds.Api.Controllers
{
    [Route("api/bills")]
    [CustomAuthorize]
    public class BillController : ApiControllerBase
    {
        private readonly ILogger<PersonController> logger;
        private readonly IMapper mapper;
        private readonly IBillService billService;
        private readonly IClientService clientService;

        public BillController(
            ILogger<PersonController> logger,
            IMapper mapper,
            IBillService billService,
            IClientService clientService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.billService = billService;
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
                    Items = mapper.Map<List<BillDto>>(paidBills),
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
                    return Ok(new CreateCostResponse{Id = billId});
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