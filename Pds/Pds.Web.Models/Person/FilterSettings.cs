namespace Pds.Web.Models.Person;

public class FilterSettings
{
    public List<BrandFilterItem> BrandFilterItems { get; set; }
    
    public List<PersonStatusFilterItem> PersonStatusFilterItems { get; set; }
    
    public bool IsContactEstablished { get; set; }
    
    public bool IsUnknownPersons { get; set; }
}