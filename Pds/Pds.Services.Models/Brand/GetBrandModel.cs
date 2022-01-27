namespace Pds.Services.Models.Brand;

public class GetBrandModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public string Info { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    
    public decimal BillsSum  { get; set; }

    public decimal CostsSum  { get; set; }

    public int ContentsCount  { get; set; }

    public int PersonsCount  { get; set; }

    public int GiftsCount { get; set; }
    
    public  bool IsDeletable { get; set; }
}