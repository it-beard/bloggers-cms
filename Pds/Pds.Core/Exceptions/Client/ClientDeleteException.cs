namespace Pds.Core.Exceptions.Client;

public class ClientDeleteException : Exception, IApiException
{
    public List<string> Errors { get; }

    public ClientDeleteException(List<string> errors)
    {
        Errors = errors;
    }

    public ClientDeleteException(string message)
        : base(message)
    {
        Errors = new List<string> { message };
    }

    public ClientDeleteException(string message, Exception inner)
        : base(message, inner)
    {
    }
}