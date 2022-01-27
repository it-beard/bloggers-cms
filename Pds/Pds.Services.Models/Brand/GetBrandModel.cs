namespace Pds.Services.Models.Brand;

public class GetBrandModel : BrandAdditionalInfoModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public string Info { get; set; }
    
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}