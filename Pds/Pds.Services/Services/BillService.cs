using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pds.Core.Enums;
using Pds.Core.Exceptions.Bill;
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
                bill.PaymentStatus = PaymentStatus.Paid;
                bill.UpdatedAt = DateTime.UtcNow;
                bill.PaidAt = model.PaidAt;
                bill.IsNeedPayNds = model.IsNeedPayNds;
                bill.ContractNumber = model.ContractNumber;
                bill.ContractDate = model.ContractDate;

                await unitOfWork.Bills.UpdateAsync(bill);
            }
        }

        public async Task<Bill> GetAsync(Guid billId)
        {
            return await unitOfWork.Bills.GetFullByIdAsync(billId);
        }

        public async Task<List<Bill>> GetAllPaidAsync()
        {
            return await unitOfWork.Bills.GetAllPaidOrderByDateDescAsync();
        }

        public async Task<Guid> CreateAsync(Bill bill)
        {
            if (bill == null)
            {
                throw new BillCreateException("Запрос был пуст.");
            }

            if (bill.Type == BillType.Content)
            {
                throw new BillCreateException("Счета типа \"Контент\" добавляются через создание контента.");
            }

            bill.CreatedAt = DateTime.UtcNow;
            bill.PaymentStatus = PaymentStatus.Paid;
            bill.Status = BillStatus.Active;
            if (bill.ClientId == Guid.Empty)
            {
                bill.ClientId = null;
                bill.ContactName = null;
                bill.Contact = null;
                bill.ContactType = null;
            }
            var result = await unitOfWork.Bills.InsertAsync(bill);

            return result.Id;
        }
        
        public async Task<Guid> EditAsync(EditBillModel model)
        {
            if (model == null)
            {
                throw new BillEditException($"Модель запроса пуста.");
            }

            var bill = await unitOfWork.Bills.GetFullByIdAsync(model.Id);
            
            if (bill == null)
            {
                throw new BillEditException($"Доход с id {model.Id} не найден.");
            }

            if (bill.Status == BillStatus.Archived)
            {
                throw new BillEditException($"Нельзя редактировать архивный доход.");
            }

            bill.UpdatedAt = DateTime.UtcNow;
            bill.Value = model.Value;
            bill.Comment = model.Comment;
            bill.PaidAt = model.PaidAt;
            bill.Comment = model.Comment;
            bill.Type = model.Type;
            bill.PaymentType = model.PaymentType;
            bill.IsNeedPayNds = model.IsNeedPayNds;
            bill.ContractNumber = model.ContractNumber;
            bill.ContractDate = model.ContractDate;
            bill.BrandId = model.BrandId;
            bill.UpdatedAt = DateTime.UtcNow;

            var result = await unitOfWork.Bills.UpdateAsync(bill);

            return result.Id;
        }

        public async Task ArchiveAsync(Guid billId)
        {
            var bill = await unitOfWork.Bills.GetFirstWhereAsync(p => p.Id == billId);
            if (bill != null)
            {
                bill.Status = BillStatus.Archived;
                bill.UpdatedAt = DateTime.UtcNow;
                await unitOfWork.Bills.UpdateAsync(bill);
            }
        }

        public async Task UnarchiveAsync(Guid billId)
        {
            var bill = await unitOfWork.Bills.GetFirstWhereAsync(p => p.Id == billId);
            if (bill is {Status: BillStatus.Archived})
            {
                bill.Status = BillStatus.Active;
                bill.UpdatedAt = DateTime.UtcNow;
                await unitOfWork.Bills.UpdateAsync(bill);
            }
        }

        public async Task DeleteAsync(Guid billId)
        {
            var bill = await unitOfWork.Bills.GetFirstWhereAsync(p => p.Id == billId);
            
            if (bill == null)
            {
                throw new BillDeleteException($"Доход с id {billId} не найден.");
            }
            
            if (bill.Status == BillStatus.Archived)
            {
                throw new BillDeleteException($"Нельзя удалить архивный доход.");
            }
            
            if (bill.Content != null)
            {
                throw new BillDeleteException($"Доход, привязанный к контенту, удаляется только через контент.");
            }

            await unitOfWork.Bills.Delete(bill);
        }
    }
}