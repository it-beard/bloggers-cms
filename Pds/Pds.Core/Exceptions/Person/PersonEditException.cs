using System;
using System.Collections.Generic;

namespace Pds.Core.Exceptions.Person
{
    public class PersonEditException : Exception, IApiException
    {
        public List<string> Errors { get; }

        public PersonEditException(List<string> errors)
        {
            Errors = errors;
        }

        public PersonEditException(string message)
            : base(message)
        {
            Errors = new List<string> { message };
        }

        public PersonEditException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}