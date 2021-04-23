using System;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Bill
{
    public class BillContentDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public SocialMediaType SocialMediaType { get; set; }
    }
}