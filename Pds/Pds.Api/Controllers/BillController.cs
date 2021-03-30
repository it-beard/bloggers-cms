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
    [Route("api/bill")]
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
                    Cost = payload.Cost,
                    Comment = payload.Comment,
                    PaymentType = payload.PaymentType
                };
                await billService.PayBillAsync(model);
                
                return Ok();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}