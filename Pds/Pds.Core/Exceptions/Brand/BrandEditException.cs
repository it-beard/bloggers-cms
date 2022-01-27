namespace Pds.Core.Exceptions.Brand;

public class BrandEditException : Exception, IApiException
{
    public List<string> Errors { get; }

    public BrandEditException(List<string> errors)
    {
        Errors = errors;
    }

    public BrandEditException(string message)
        : base(message)
    {
        Errors = new List<string> { message };
    }

    public BrandEditException(string message, Exception inner)
        : base(message, inner)
    {
    }
}