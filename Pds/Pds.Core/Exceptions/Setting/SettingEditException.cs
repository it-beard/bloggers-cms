namespace Pds.Core.Exceptions.Setting;

public class SettingEditException : Exception, IApiException
{
    public List<string> Errors { get; }

    public SettingEditException(List<string> errors)
    {
        Errors = errors;
    }

    public SettingEditException(string message)
        : base(message)
    {
        Errors = new List<string> { message };
    }

    public SettingEditException(string message, Exception inner)
        : base(message, inner)
    {
    }
}