using System;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content
{
    public class ContentDto
    {
        public string Id { get; set; }
        
        public bool IsVisible { get; set; }
        
        public string Title { get; set; }
        
        public ContentStatus Status { get; set; }
        
        public string ClientName { get; set; }
        
        public DateTime ReleaseDateUtc { get; set; }

        public DateTime? EndDateUtc { get; set; }
        
        public SocialMediaType SocialMediaType { get; set; }

        public ContentType Type { get; set; }

        public ContentListBillDto Bill { get; set; }
    }
}