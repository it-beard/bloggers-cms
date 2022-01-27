namespace Pds.Core.Exceptions.Brand;

public class BrandCreateException : Exception, IApiException
{
    public List<string> Errors { get; }

    public BrandCreateException(List<string> errors)
    {
        Errors = errors;
    }

    public BrandCreateException(string message)
        : base(message)
    {
        Errors = new List<string> { message };
    }

    public BrandCreateException(string message, Exception inner)
        : base(message, inner)
    {
    }
}