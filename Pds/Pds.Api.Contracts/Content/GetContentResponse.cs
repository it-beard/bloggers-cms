using System;
using System.Collections.Generic;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content
{
    public class GetContentResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        
        public ContentType Type { get; set; }
        
        public ContentStatus Status { get; set; }
        
        public SocialMediaType SocialMediaType { get; set; }

        public string Comment { get; set; }
        
        public DateTime ReleaseDateUtc { get; set; }

        public DateTime? EndDateUtc { get; set; }

        public GetContentBillDto Bill { get; set; }

        public BrandDto Brand { get; set; }

        public GetContentPersonDto Person { get; set; }

        public List<GetContentCostDto> Costs { get; set; }
    }
}