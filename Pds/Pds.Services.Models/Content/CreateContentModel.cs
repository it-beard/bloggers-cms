using System;
using Pds.Core.Enums;

namespace Pds.Services.Models
{
    public class CreateContentModel
    {
        public Guid ChannelId { get; set; }
        
        public Guid ClientId { get; set; }

        public Guid? PersonId { get; set; }

        public ContentType Type { get; set; }

        public SocialMediaType SocialMediaType { get; set; }
        
        public string Title { get; set; }

        public string Comment { get; set; }
        
        public DateTime ReleaseDate { get; set; }

        public DateTime? EndDate { get; set; }
        
        public string BillContact { get; set; }
        
        public ContactType BillContactType { get; set; }

        public decimal BillCost { get; set; }
    }
}