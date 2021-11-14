using System.ComponentModel.DataAnnotations;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Gift;

public class CreateGiftRequest
{
    [Required]
    public Guid BrandId { get; set; }
    
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

    public Guid? ContentId { get; set; }
}