using System;
using System.Collections.Generic;

namespace Pds.Core.Exceptions.Person
{
    public class PersonCreationException : Exception, IApiException
    {
        public List<string> Errors { get; }

        public PersonCreationException(List<string> errors)
        {
            Errors = errors;
        }

        public PersonCreationException(string message)
            : base(message)
        {
            Errors = new List<string> { message };
        }

        public PersonCreationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}