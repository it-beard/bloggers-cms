using System;
using System.Collections.Generic;

namespace Pds.Core.Exceptions.Person
{
    public class PersonCreateException : Exception, IApiException
    {
        public List<string> Errors { get; }

        public PersonCreateException(List<string> errors)
        {
            Errors = errors;
        }

        public PersonCreateException(string message)
            : base(message)
        {
            Errors = new List<string> { message };
        }

        public PersonCreateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}