using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace Pds.Web.Components
{
    public partial class PagingComponent
    {
        [Parameter]
        public EventCallback<PaginationSettings> Pagination { get; set; }
        [Parameter]
        public int[] PageSizeList { get; set; }
        [Parameter]
        public int TotalItems { get; set; }
        [Parameter]
        public int Radius { get; set; }

        [Parameter]
        public int CurrentPage { get; set; }

        private int pageOffset;
        //private int currentPage;
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
                CurrentPage = 1;
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
            if (page.Page == CurrentPage)
            {
                return;
            }

            if (!page.Enabled)
            {
                return;
            }
            CurrentPage = page.Page;
            pageOffset = (CurrentPage - 1) * currentPageSize;
            PaginationInvoke();
        }

        private void PaginationInvoke()
        {
            var settings = new PaginationSettings(currentPageSize, pageOffset, CurrentPage);
            Pagination.InvokeAsync(settings);
        }

        private void SetDefaultPagination()
        {
            pageOffset = default;
            CurrentPage = 1;
            LoadPages();
        }

        private void LoadPages()
        {
            pages = new List<PageModel>();
            var isPreviousPageLinkEnabled = CurrentPage > 1 && totalPages > 0;

            var previousPage = CurrentPage - 1;
            pages.Add(new PageModel(previousPage, isPreviousPageLinkEnabled, "Previous"));

            for (int i = 1; i <= totalPages; i++)
            {
                if (i > CurrentPage - Radius && i < CurrentPage + Radius)
                {
                    pages.Add(new PageModel(i) { Active = CurrentPage == i });
                }
            }

            var isNextPageLinkEnabled = CurrentPage < totalPages && totalPages > 0;
            var nextPage = CurrentPage + 1;
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
        public int CurrentPage { get; }
        public int PageSize { get; }
        public int PageOffSet { get; }

        public PaginationSettings(int pageSize, int pageOffSet, int currentPage)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            PageOffSet = pageOffSet;
        }
    }
}

