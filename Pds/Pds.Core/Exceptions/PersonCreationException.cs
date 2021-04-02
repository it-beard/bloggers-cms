using System;
using System.Collections.Generic;

namespace Pds.Core.Exceptions
{
    public class PersonCreationException : Exception
    {
        public List<string> Errors;

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