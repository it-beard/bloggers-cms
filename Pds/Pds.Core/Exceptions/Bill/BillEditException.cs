using System;
using System.Collections.Generic;

namespace Pds.Core.Exceptions.Bill
{
    public class BillEditException : Exception, IApiException
    {
        public List<string> Errors { get; }

        public BillEditException(List<string> errors)
        {
            Errors = errors;
        }

        public BillEditException(string message)
            : base(message)
        {
            Errors = new List<string> { message };
        }

        public BillEditException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}