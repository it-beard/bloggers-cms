namespace Pds.Core.Exceptions.Client;

public class ClientEditException : Exception, IApiException
{
    public List<string> Errors { get; }

    public ClientEditException(List<string> errors)
    {
        Errors = errors;
    }

    public ClientEditException(string message)
        : base(message)
    {
        Errors = new List<string> { message };
    }

    public ClientEditException(string message, Exception inner)
        : base(message, inner)
    {
    }
}