namespace Pds.Services.Models.Person;

public class EditPersonModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string ThirdName { get; set; }

    public string Country { get; set; }

    public string City { get; set; }
        
    public string Topics { get; set; }

    public string Info { get; set; }

    public int? Rate { get; set; }

    public List<BrandForCheckboxesModel> Brands { get; set; }
    
    public List<EditResourcePersonModel> Resources { get; set; }
}