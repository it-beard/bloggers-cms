using System.ComponentModel.DataAnnotations;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Gift;

public class GetGiftResponse
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public GiftType Type { get; set; }
    
    public GiftStatus Status { get; set; }

    public string Comment { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string ThirdName { get; set; }
    
    public string PostalAddress { get; set; }
    
    public Guid BrandId { get; set; }

    public GiftContentDto Content { get; set; }
}