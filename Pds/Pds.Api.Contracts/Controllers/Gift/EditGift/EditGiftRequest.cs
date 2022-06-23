using System.ComponentModel.DataAnnotations;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Controllers.Gift.EditGift;

public class EditGiftRequest
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public string Title { get; set; }

    [Required, EnumDataType(typeof(GiftType))]
    public GiftType Type { get; set; }

    [Required, EnumDataType(typeof(GiftStatus))]
    public GiftStatus Status { get; set; }

    public string Comment { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string ThirdName { get; set; }
    
    public string PostalAddress { get; set; }

    [Required]
    public Guid BrandId { get; set; }

    public Guid? ContentId { get; set; }

    public EditGiftContentDto Content { get; set; }
}