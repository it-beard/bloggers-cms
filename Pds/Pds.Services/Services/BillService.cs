using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Core.Enums;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Services.Interfaces;
using Pds.Services.Models.Bill;

namespace Pds.Services.Services
{
    public class BillService : IBillService
    {
        private readonly IUnitOfWork unitOfWork;

        public BillService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task PayBillAsync(PayBillModel model)
        {
            var bill = await unitOfWork.Bills.GetFirstWhereAsync(b => b.Id == model.BillId);
            if (bill != null)
            {
                bill.Value = model.Value;
                bill.PaymentType = model.PaymentType;
                bill.Comment = model.Comment;
                bill.Status = BillStatus.Paid;
                bill.UpdatedAt = DateTime.UtcNow;
                bill.PaidAt = model.PaidAt;

                await unitOfWork.Bills.UpdateAsync(bill);
            }
        }

        public async Task<List<Bill>> GetAllPaidAsync()
        {
            return await unitOfWork.Bills.GetAllPaidOrderByDateDescAsync();
        }
    }
}