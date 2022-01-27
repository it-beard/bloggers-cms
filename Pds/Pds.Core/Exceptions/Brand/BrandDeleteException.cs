namespace Pds.Core.Exceptions.Brand;

public class BrandDeleteException : Exception, IApiException
{
    public List<string> Errors { get; }

    public BrandDeleteException(List<string> errors)
    {
        Errors = errors;
    }

    public BrandDeleteException(string message)
        : base(message)
    {
        Errors = new List<string> { message };
    }

    public BrandDeleteException(string message, Exception inner)
        : base(message, inner)
    {
    }
}