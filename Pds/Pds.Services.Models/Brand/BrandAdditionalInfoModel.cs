namespace Pds.Services.Models.Brand;

public class BrandAdditionalInfoModel
{
    public decimal BillsSum  { get; set; }

    public decimal CostsSum  { get; set; }

    public int ContentsCount  { get; set; }

    public int PersonsCount  { get; set; }

    public int GiftsCount { get; set; }
    
    public  bool IsDeletable { get; set; }
}