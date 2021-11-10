namespace Pds.Core.Exceptions.Bill;

public class BillDeleteException : Exception, IApiException
{
    public List<string> Errors { get; }

    public BillDeleteException(List<string> errors)
    {
        Errors = errors;
    }

    public BillDeleteException(string message)
        : base(message)
    {
        Errors = new List<string> { message };
    }

    public BillDeleteException(string message, Exception inner)
        : base(message, inner)
    {
    }
}