using System.ComponentModel.DataAnnotations;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Content.EditContent;

public class EditContentRequest
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public Guid BrandId { get; set; }

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

        
    public Guid? BillId { get; set; }

    [ValidateComplexType]
    public EditContentBillDto Bill { get; set; }

    public Guid? PersonId { get; set; }
}