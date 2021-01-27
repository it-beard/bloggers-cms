using System;
using System.Net;
using Pds.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Pds.Api.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        private string exceptionMessage = "Something went wrong";
        private HttpStatusCode statusCode = HttpStatusCode.BadRequest;

        protected IActionResult ExceptionResult(Exception exception)
        {
            switch (exception)
            {
                case var _ when exception is RepositoryException repositoryException:
                    // logger.Log( 
                    // $"Error in DB, entityName: {repositoryException.EntityName}, " +
                    // $"message: {repositoryException.Message}" +
                    // $"stackTrace: {repositoryException.StackTrace},")
                    exceptionMessage = "DB error";
                    statusCode = HttpStatusCode.Conflict;
                    break;
                default:
                    // logger.Log(exception.Message)
                    break;
            }

            return StatusCode((int) statusCode, exceptionMessage);
        }
    }
}