namespace Pds.Api.Contracts.Controllers.Content.GetContent;

public class GetContentPersonDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }
        
    public string LastName { get; set; }
        
    public string ThirdName { get; set; }

    public string Country { get; set; }
        
    public string City { get; set; }

    public List<GetContentPersonResourceDto> Resources { get; set; }

}