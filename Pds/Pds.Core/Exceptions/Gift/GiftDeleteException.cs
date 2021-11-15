namespace Pds.Core.Exceptions.Gift;

public class GiftDeleteException : Exception, IApiException
{
    public List<string> Errors { get; }

    public GiftDeleteException(List<string> errors)
    {
        Errors = errors;
    }

    public GiftDeleteException(string message)
        : base(message)
    {
        Errors = new List<string> { message };
    }

    public GiftDeleteException(string message, Exception inner)
        : base(message, inner)
    {
    }
}