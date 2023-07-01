namespace Pds.Api.Authentication;

public class Auth0Settings
{
    public const string ConfigSectionPath = "Auth0";
    
    public string Authority { get; set; }
    public string ApiIdentifier { get; set; }
    public string AllowedAppId { get; set; }
}