using System.Collections.Generic;

namespace Pds.Core.Exceptions
{
    public interface IApiException
    {
        List<string> Errors { get; }
    }
}