using PaginationWithVirtualizationBlazorApp.Data;

namespace PaginationWithVirtualizationBlazorApp.Pages
{
    public partial class FetchData
    {
        private List<WeatherForecast>? allForecasts;
        private List<WeatherForecast>? forecasts;
        private const int _itemsPerPage = 2;
        private int _totalPages;
        private int _page = 0;

        protected override async Task OnInitializedAsync()
        {
            allForecasts = await ForecastService.GetForecastAsync(DateTime.Now);
            if (allForecasts is not null)
            {
                _totalPages = (int)allForecasts.Count / _itemsPerPage;
                PaginateForecasts();
            }
        }

        void PageChanged(int pageNumber)
        {
            _page = pageNumber;
            if (forecasts is not null)
                PaginateForecasts();
        }

        void PaginateForecasts()
        {
            forecasts = allForecasts?
                    .Skip((_page - 1) * _itemsPerPage)
                    .Take(_itemsPerPage)
                    .ToList();

            StateHasChanged();
        }
    }
}
