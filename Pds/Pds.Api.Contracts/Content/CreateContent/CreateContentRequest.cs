using System.ComponentModel.DataAnnotations;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Content.CreateContent;

public class CreateContentRequest
{
    [Required]
    public Guid? BrandId { get; set; }

    [Required, EnumDataType(typeof(ContentType))]
    public ContentType Type { get; set; }

    [Required, EnumDataType(typeof(SocialMediaType))]
    public SocialMediaType SocialMediaType { get; set; }

    [Required]
    public string Title { get; set; }

    public string Comment { get; set; }

    [Required]
    public DateTime ReleaseDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool IsFree { get; set; }

    [ValidateComplexType]
    public CreateContentBillDto Bill { get; set; }

    public Guid? PersonId { get; set; }
}