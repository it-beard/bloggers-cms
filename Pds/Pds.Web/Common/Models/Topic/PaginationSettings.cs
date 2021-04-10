using System;

namespace Pds.Web.Common.Models.Topic
{
    public class PaginationSettings
    {
        public int Offset => PageSize * CurrentPage;

        public int PageCount => (int) Math.Ceiling((decimal) Total / PageSize);

        public int PageSize { get; set; } = 5;

        public int CurrentPage { get; set; }

        public int Total { get; set; }
    }
}