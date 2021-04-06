using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pds.Api.Authentication;
using Pds.Api.Contracts.Bill;
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

        public BillController(
            ILogger<PersonController> logger,
            IMapper mapper,
            IBillService billService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.billService = billService;
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
                    PaidAt = payload.PaidAt
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
                    Items = mapper.Map<BillDto[]>(paidBills),
                    Total = paidBills.Count
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