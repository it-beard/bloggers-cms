using System.Collections.Generic;
using Pds.Api.Contracts.Person;
using Pds.Api.Contracts.Topic;

namespace Pds.Api.Contracts.Paging
{
    public class PageResult<T>
    {
        public List<T> Items { get; set; }
        public int Total { get; set; }
    }
}