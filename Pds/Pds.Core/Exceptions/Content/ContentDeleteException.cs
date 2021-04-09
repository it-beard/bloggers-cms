using System;
using System.Collections.Generic;

namespace Pds.Core.Exceptions.Content
{
    public class ContentDeleteException : Exception, IApiException
    {
        public List<string> Errors { get; }

        public ContentDeleteException(List<string> errors)
        {
            Errors = errors;
        }

        public ContentDeleteException(string message)
            : base(message)
        {
            Errors = new List<string> { message };
        }

        public ContentDeleteException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}