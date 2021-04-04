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
    }
}