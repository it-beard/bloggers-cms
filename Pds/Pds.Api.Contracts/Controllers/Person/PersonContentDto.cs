namespace Pds.Api.Contracts.Controllers.Person;

public class PersonContentDto
{
    public Guid Id { get; set; }
        
    public string Title { get; set; }
    
    public DateTime ReleaseDate { get; set; }
}