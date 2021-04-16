using System;
using Pds.Core.Enums;

namespace Pds.Services.Models.Content
{
    public class CreateContentModel
    {
        public Guid BrandId { get; set; }

        public Guid? PersonId { get; set; }

        public ContentType Type { get; set; }

        public SocialMediaType SocialMediaType { get; set; }
        
        public string Title { get; set; }

        public string Comment { get; set; }
        
        public DateTime ReleaseDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsFree { get; set; }
        
        public CreateContentBillModel Bill { get; set; }
    }
}