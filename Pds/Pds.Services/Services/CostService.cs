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
    public class CostService : ICostService
    {
        private readonly IUnitOfWork unitOfWork;

        public CostService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Cost>> GetAllAsync()
        {
            return await unitOfWork.Costs.GetAllOrderByDateDescAsync();
        }

        public async Task<Guid> CreateAsync(Cost cost)
        {
            if (cost == null)
            {
                throw new ArgumentNullException(nameof(cost));
            }

            cost.CreatedAt = DateTime.UtcNow;
            var result = await unitOfWork.Costs.InsertAsync(cost);

            return result.Id;
        }

        public async Task DeleteAsync(Guid costId)
        {
            var cost = await unitOfWork.Costs.GetFirstWhereAsync(p => p.Id == costId);
            if (cost != null)
            {
                await unitOfWork.Costs.Delete(cost);
            }
        }
    }
}