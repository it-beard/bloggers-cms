namespace Pds.Core.Exceptions.Gift;

public class GiftEditException : Exception, IApiException
{
    public List<string> Errors { get; }

    public GiftEditException(List<string> errors)
    {
        Errors = errors;
    }

    public GiftEditException(string message)
        : base(message)
    {
        Errors = new List<string> { message };
    }

    public GiftEditException(string message, Exception inner)
        : base(message, inner)
    {
    }
}