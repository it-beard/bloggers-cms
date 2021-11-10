namespace Pds.Core.Exceptions.Content;

public class ContentEditException : Exception, IApiException
{
    public List<string> Errors { get; }

    public ContentEditException(List<string> errors)
    {
        Errors = errors;
    }

    public ContentEditException(string message)
        : base(message)
    {
        Errors = new List<string> { message };
    }

    public ContentEditException(string message, Exception inner)
        : base(message, inner)
    {
    }
}