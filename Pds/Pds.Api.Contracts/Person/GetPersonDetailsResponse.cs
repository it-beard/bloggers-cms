namespace Pds.Api.Contracts.Person;

public class GetPersonDetailsResponse
{
    public string Id { get; set; }
        
    /// <summary>
    /// Contains LastName FirstName [ThirdName]
    /// </summary>
    public string FullName { get; set; }
        
    /// <summary>
    /// General information about person
    /// </summary>
    public string Information { get; set; }
        
    /// <summary>
    /// Rate (int) - can be from 0 to 100 and used to understanding how attractable/hot user for the show
    /// </summary>
    public int Rate { get; set; }
}