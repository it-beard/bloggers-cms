using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Pds.Web.Components
{
    public class PagingComponentBase : ComponentBase
    {
        [Parameter]
        public EventCallback<PaginationSettings> Pagination { get; set; }
        [Parameter]
        public int[] PageSizeList { get; set; }
        [Parameter]
        public int TotalItems { get; set; }
        [Parameter]
        public int Radius { get; set; }

        private int pageOffset;
        private int currentPage;
        private int totalPages;
        private int currentPageSize;

        protected List<PageModel> pages;

        protected override void OnInitialized()
        {
            currentPageSize = PageSizeList[0];
            SetDefaultPagination();
        }

        protected override void OnParametersSet()
        {
            totalPages = (int)Math.Ceiling(TotalItems / (double)currentPageSize);
            if (totalPages <= 1)
                currentPage = 1;
            LoadPages();
        }

        protected void OnChangePageSize(ChangeEventArgs e)
        {
            var isPageSizeChanged = int.TryParse(e.Value.ToString(), out currentPageSize);
            if (!isPageSizeChanged)
                currentPageSize = PageSizeList[0];

            SetDefaultPagination();
            PaginationInvoke();
        }

        protected void OnChangePage(PageModel page)
        {
            if (page.Page == currentPage)
            {
                return;
            }

            if (!page.Enabled)
            {
                return;
            }
            currentPage = page.Page;
            pageOffset = (currentPage - 1) * currentPageSize;
            PaginationInvoke();
        }

        private void PaginationInvoke()
        {
            var settings = new PaginationSettings(currentPageSize, pageOffset);
            Pagination.InvokeAsync(settings);
        }

        private void SetDefaultPagination()
        {
            pageOffset = default;
            currentPage = 1;
            LoadPages();
        }

        private void LoadPages()
        {
            pages = new List<PageModel>();
            var isPreviousPageLinkEnabled = currentPage > 1 && totalPages > 0;

            var previousPage = currentPage - 1;
            pages.Add(new PageModel(previousPage, isPreviousPageLinkEnabled, "Previous"));

            for (int i = 1; i <= totalPages; i++)
            {
                if (i > currentPage - Radius && i < currentPage + Radius)
                {
                    pages.Add(new PageModel(i) { Active = currentPage == i });
                }
            }

            var isNextPageLinkEnabled = currentPage < totalPages && totalPages > 0;
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

    public struct PaginationSettings
    {
        public int PageSize { get; }
        public int PageOffSet { get; }

        public PaginationSettings(int pageSize, int pageOffSet)
        {
            PageSize = pageSize;
            PageOffSet = pageOffSet;
        }
    }
}

