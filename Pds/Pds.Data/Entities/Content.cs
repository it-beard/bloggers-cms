using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pds.Data.Enums;

namespace Pds.Data.Entities
{
    public class Content : EntityBase
    {
        [Required]
        [Column(TypeName = "varchar(300)")]
        public string Title { get; set; }

        [Required]
        public ContentType Type { get; set; }

        [Required]
        public SocialMediaType SocialMediaType { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public DateTime ReleaseDateUtc { get; set; }

        public DateTime? EndDateUtc { get; set; }

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string PrimaryContact { get; set; }

        public Guid OrderId { get; set; }

        public Guid ChannelId { get; set; }

        public Guid? PersonId { get; set; }

        public virtual Order Order { get; set; }

        public virtual Channel Channel { get; set; }

        public virtual Person Person { get; set; }
    }
}