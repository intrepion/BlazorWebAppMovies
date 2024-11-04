namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.CastMemberMovieGrid;

// Interface for filtering.
public interface ICastMemberMovieFilters
{
    // The CastMemberMovieFilterColumns being filtered on.
    CastMemberMovieFilterColumns FilterColumn { get; set; }

    // Loading indicator.
    bool Loading { get; set; }

    // The text of the filter.
    string? FilterText { get; set; }

    // Paging state in PageHelper.
    IPageHelper PageHelper { get; set; }

    // Gets or sets a value indicating if the sort is ascending or descending.
    bool SortAscending { get; set; }

    // The CastMemberMovieFilterColumns being sorted.
    CastMemberMovieFilterColumns SortColumn { get; set; }
}
