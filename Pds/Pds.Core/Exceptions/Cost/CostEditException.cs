using System;
using System.Collections.Generic;

namespace Pds.Core.Exceptions.Cost
{
    public class CostEditException : Exception, IApiException
    {
        public List<string> Errors { get; }

        public CostEditException(List<string> errors)
        {
            Errors = errors;
        }

        public CostEditException(string message)
            : base(message)
        {
            Errors = new List<string> { message };
        }

        public CostEditException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}