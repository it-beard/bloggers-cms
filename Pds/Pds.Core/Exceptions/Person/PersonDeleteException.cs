namespace Pds.Core.Exceptions.Person;

public class PersonDeleteException : Exception, IApiException
{
    public List<string> Errors { get; }

    public PersonDeleteException(List<string> errors)
    {
        Errors = errors;
    }

    public PersonDeleteException(string message)
        : base(message)
    {
        Errors = new List<string> { message };
    }

    public PersonDeleteException(string message, Exception inner)
        : base(message, inner)
    {
    }
}