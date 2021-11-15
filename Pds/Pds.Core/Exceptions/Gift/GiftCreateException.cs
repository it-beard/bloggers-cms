namespace Pds.Core.Exceptions.Gift;

public class GiftCreateException : Exception, IApiException
{
    public List<string> Errors { get; }

    public GiftCreateException(List<string> errors)
    {
        Errors = errors;
    }

    public GiftCreateException(string message)
        : base(message)
    {
        Errors = new List<string> { message };
    }

    public GiftCreateException(string message, Exception inner)
        : base(message, inner)
    {
    }
}