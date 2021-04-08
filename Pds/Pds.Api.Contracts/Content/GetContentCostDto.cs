using System;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content
{
    public class GetContentCostDto
    {
        public Guid Id { get; set; }

        public decimal Value { get; set; }

        public DateTime PaidAt { get; set; }

        public CostType Type { get; set; }

        public string Comment { get; set; }
    }
}