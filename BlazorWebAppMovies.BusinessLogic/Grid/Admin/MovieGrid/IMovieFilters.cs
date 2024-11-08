namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.MovieGrid;

// Interface for filtering.
public interface IMovieFilters
{
    // The MovieFilterColumns being filtered on.
    MovieFilterColumns FilterColumn { get; set; }

    // Loading indicator.
    bool Loading { get; set; }

    // The text of the filter.
    string? FilterText { get; set; }

    // Paging state in PageHelper.
    IPageHelper PageHelper { get; set; }

    // Gets or sets a value indicating if the sort is ascending or descending.
    bool SortAscending { get; set; }

    // The MovieFilterColumns being sorted.
    MovieFilterColumns SortColumn { get; set; }
}
