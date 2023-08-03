using System.Net;
using Pds.Core.Exceptions;

namespace Pds.Api.Controllers;

[ApiController]
[Produces("application/json")]
public abstract class ApiControllerBase : ControllerBase
{
    protected IActionResult ExceptionResult(Exception exception)
    {
        return exception switch
        {
            RepositoryException => 
                StatusCode((int) HttpStatusCode.BadRequest, $"DB error: {exception.Message}" + 
                                                            Environment.NewLine + 
                                                            $"{exception.InnerException.Message}"),
            IApiException apiException => 
                StatusCode((int) HttpStatusCode.BadRequest, apiException.Errors),

            _ => 
                StatusCode((int) HttpStatusCode.BadRequest, $"Smtg went wrong: {exception.Message}" + 
                                                            Environment.NewLine + 
                                                            $"{exception.InnerException.Message}")
        };
    }
}