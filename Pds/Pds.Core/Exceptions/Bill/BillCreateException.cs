namespace Pds.Core.Exceptions.Bill;

public class BillCreateException : Exception, IApiException
{
    public List<string> Errors { get; }

    public BillCreateException(List<string> errors)
    {
        Errors = errors;
    }

    public BillCreateException(string message)
        : base(message)
    {
        Errors = new List<string> { message };
    }

    public BillCreateException(string message, Exception inner)
        : base(message, inner)
    {
    }
}