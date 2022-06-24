namespace Pds.Core.Exceptions.Brand;

public class BrandArchiveException : Exception, IApiException
{
    public List<string> Errors { get; }

    public BrandArchiveException(List<string> errors)
    {
        Errors = errors;
    }

    public BrandArchiveException(string message)
        : base(message)
    {
        Errors = new List<string> { message };
    }

    public BrandArchiveException(string message, Exception inner)
        : base(message, inner)
    {
    }
}