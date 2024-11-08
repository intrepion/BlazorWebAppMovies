namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.MovieGrid;

// State of grid filters.
public class MovieGridControls(IPageHelper pageHelper) : IMovieFilters
{
    // Keep state of paging.
    public IPageHelper PageHelper { get; set; } = pageHelper;

    // Avoid multiple concurrent requests.
    public bool Loading { get; set; }

    // Column to sort by.
    public MovieFilterColumns SortColumn { get; set; } = MovieFilterColumns.Id;

    // True when sorting ascending, otherwise sort descending.
    public bool SortAscending { get; set; } = true;

    // Column filtered text is against.
    public MovieFilterColumns FilterColumn { get; set; } = MovieFilterColumns.Id;

    // Text to filter on.
    public string? FilterText { get; set; }
}
