using Microsoft.AspNetCore.Components;
using PaginationWithVirtualizationBlazorApp.Data;

namespace PaginationWithVirtualizationBlazorApp.Components
{
    public partial class PaginationComponent
    {
        [Parameter]
        public int totalPages { get; set; }
        [Parameter]
        public EventCallback<int> OnPageChange { get; set; }

        private int _currentPage = 1;
        private List<PageItem>? _pageItems;
        private int _radius = 2;

        private bool _isFirstPage => _currentPage == 1;
        private bool _isLastPage => _currentPage == totalPages;

        // create page item
        protected override void OnParametersSet()
        {
            _pageItems = new();

            if (_radius >= totalPages)
                _radius = totalPages - 1;

            for(int pageNumber = 1; pageNumber <= totalPages; pageNumber++)
            {
                if (pageNumber >= _currentPage - _radius && pageNumber < _currentPage + _radius)
                {
                    _pageItems.Add(new PageItem(pageNumber.ToString(), pageNumber, true, (pageNumber == _currentPage)));
                }
            }
        }

        async Task GoToPreviousPage()
        {
            if (!_isFirstPage)
                _currentPage--;

            await OnPageChange.InvokeAsync(_currentPage);
        }
        async Task GoToNextPage()
        {
            if (!_isLastPage)
                _currentPage++;

            await OnPageChange.InvokeAsync(_currentPage);
        }

        async Task GoToPage(PageItem pageItem)
        {
            if (_currentPage == pageItem.PageIndex || !pageItem.IsEnabled)
                return;

            _currentPage = pageItem.PageIndex;

            await OnPageChange.InvokeAsync(_currentPage);
        }
    }
}
