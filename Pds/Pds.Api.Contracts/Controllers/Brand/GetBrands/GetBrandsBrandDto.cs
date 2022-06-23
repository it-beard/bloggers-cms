namespace Pds.Api.Contracts.Controllers.Brand.GetBrands;

public class GetBrandsBrandDto : IActionsBrand
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