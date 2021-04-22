using System;
using System.Collections.Generic;

namespace Pds.Core.Exceptions.Cost
{
    public class CostDeleteException : Exception, IApiException
    {
        public List<string> Errors { get; }

        public CostDeleteException(List<string> errors)
        {
            Errors = errors;
        }

        public CostDeleteException(string message)
            : base(message)
        {
            Errors = new List<string> { message };
        }

        public CostDeleteException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}