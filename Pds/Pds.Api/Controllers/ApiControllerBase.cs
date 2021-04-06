using System;
using System.Net;
using Pds.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Pds.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IActionResult ExceptionResult(Exception exception)
        {
            return exception switch
            {
                _ when exception is RepositoryException => 
                    StatusCode((int) HttpStatusCode.BadRequest, "DB error"),
                _ when exception is IApiException apiException => 
                    StatusCode((int) HttpStatusCode.BadRequest, apiException.Errors),

                _ => 
                    StatusCode((int) HttpStatusCode.BadRequest, "Smtg went wrong")
            };
        }
    }
}