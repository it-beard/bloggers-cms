using System;
using System.Collections.Generic;

namespace Pds.Core.Exceptions.Client
{
    public class ClientCreateException : Exception, IApiException
    {
        public List<string> Errors { get; }

        public ClientCreateException(List<string> errors)
        {
            Errors = errors;
        }

        public ClientCreateException(string message)
            : base(message)
        {
            Errors = new List<string> { message };
        }

        public ClientCreateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}