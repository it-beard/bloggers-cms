using System;
using Pds.Core.Enums;

namespace Pds.Services.Models.Content
{
    public class ContentBillModel
    {
        public Guid ClientId { get; set; }

        public string Contact { get; set; }

        public string ContactName { get; set; }
        
        public ContactType ContactType { get; set; }

        public decimal Cost { get; set; }
        
    }
}