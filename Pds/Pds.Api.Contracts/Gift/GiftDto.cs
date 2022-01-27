using Pds.Api.Contracts.Brand;
using Pds.Api.Contracts.Content;
using Pds.Core.Enums;

namespace Pds.Api.Contracts.Gift;

public class GiftDto
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Comment { get; set; }

    public GiftStatus Status { get; set; }

    public GiftType Type { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }

    public string ThirdName { get; set; }
    
    public string PostalAddress { get; set; }

    public DateTime SortDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? RaffledAt { get; set; }

    public DateTime? CompletedAt { get; set; }
        
    public virtual BrandDto Brand { get; set; }

    public virtual GiftContentDto Content { get; set; }
}