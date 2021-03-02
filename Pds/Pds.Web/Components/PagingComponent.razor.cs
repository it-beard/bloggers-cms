using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Pds.Web.Components
{
    public class PagingComponentBase : ComponentBase
    {
        [Parameter]
        public EventCallback<int> Pagination { get; set; }

        [Parameter]
        public int PageSize { get; set; }
        [Parameter]
        public int TotalItems { get; set; }
        [Parameter]
        public int Radius { get; set; }

        private int pageOffset = 0;
        private int currentPage = 1;
        private int totalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);

        protected List<PageModel> pages;

        protected override void OnParametersSet()
        {
            LoadPages();
        }

        protected void SelectedPage(PageModel page)
        {
            if (page.Page == currentPage)
            {
                Console.WriteLine("Current");
                return;
            }

            if (!page.Enabled)
            {
                return;
            }

            currentPage = page.Page;
            pageOffset = (currentPage - 1) * PageSize;
            Pagination.InvokeAsync(pageOffset);
        }

        private void LoadPages()
        {
            pages = new List<PageModel>();
            var isPreviousPageLinkEnabled = currentPage != 1;
            var previousPage = currentPage - 1;
            pages.Add(new PageModel(previousPage, isPreviousPageLinkEnabled, "Previous"));

            for (int i = 1; i <= totalPages; i++)
            {
                if (i > currentPage - Radius && i < currentPage + Radius)
                {
                    pages.Add(new PageModel(i) { Active = currentPage == i });
                }
            }

            var isNextPageLinkEnabled = currentPage != totalPages;
            var nextPage = currentPage + 1;
            pages.Add(new PageModel(nextPage, isNextPageLinkEnabled, "Next"));
        }

        protected class PageModel
        {
            public string Text { get; set; }
            public int Page { get; set; }
            public bool Enabled { get; set; } = true;
            public bool Active { get; set; } = false;

            public PageModel(int page) : this(page, true) { }

            public PageModel(int page, bool enabled) : this(page, enabled, page.ToString()) { }

            public PageModel(int page, bool enabled, string text)
            {
                Page = page;
                Enabled = enabled;
                Text = text;
            }
        }
    }
}
