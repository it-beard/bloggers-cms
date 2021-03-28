using System;
using System.ComponentModel.DataAnnotations;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content
{
    public class CreateContentRequest
    {
        [Required]
        public Guid? ChannelId { get; set; }

        [Required, EnumDataType(typeof(ContentType))]
        public ContentType Type { get; set; }

        [Required, EnumDataType(typeof(SocialMediaType))]
        public SocialMediaType SocialMediaType { get; set; }

        [Required]
        public string Title { get; set; }

        public string Comment { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime? EndDateUtc { get; set; }

        [Required]
        public Guid? ClientId { get; set; }

        [Required]
        public string BillContact { get; set; }

        [Required, EnumDataType(typeof(ContactType))]
        public ContactType BillContactType { get; set; }
        
        [Required]
        [Range(0.00, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal BillCost { get; set; }

        public Guid? PersonId { get; set; }
    }
}