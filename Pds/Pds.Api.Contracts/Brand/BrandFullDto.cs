using Pds.Api.Contracts.Bill;
using Pds.Api.Contracts.Content.GetContents;
using Pds.Api.Contracts.Cost;
using Pds.Api.Contracts.Gift;
using Pds.Api.Contracts.Person;

namespace Pds.Api.Contracts.Brand;

public class BrandFullDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Info { get; set; }
    
    public bool IsDefault { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    
    public decimal BillsSum  { get; set; }

    public decimal CostsSum  { get; set; }

    public int ContentsCount  { get; set; }

    public int PersonsCount  { get; set; }

    public int GiftsCount { get; set; }
    
    public  bool IsDeletable { get; set; }
}