using System;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Person
{
    public class ContentDto
    {
        public string Id { get; set; }
        
        public string Title { get; set; }
        
        public DateTime ReleaseDateUtc { get; set; }

        public DateTime? EndDateUtc { get; set; }
        
        public SocialMediaType SocialMediaType { get; set; }
        
        public ContentType Type { get; set; }
    }
}