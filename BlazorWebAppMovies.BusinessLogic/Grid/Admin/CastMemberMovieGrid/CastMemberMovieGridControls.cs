namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.CastMemberMovieGrid;

// State of grid filters.
public class CastMemberMovieGridControls(IPageHelper pageHelper) : ICastMemberMovieFilters
{
    // Keep state of paging.
    public IPageHelper PageHelper { get; set; } = pageHelper;

    // Avoid multiple concurrent requests.
    public bool Loading { get; set; }

    // Column to sort by.
    public CastMemberMovieFilterColumns SortColumn { get; set; } = CastMemberMovieFilterColumns.Id;

    // True when sorting ascending, otherwise sort descending.
    public bool SortAscending { get; set; } = true;

    // Column filtered text is against.
    public CastMemberMovieFilterColumns FilterColumn { get; set; } = CastMemberMovieFilterColumns.Id;

    // Text to filter on.
    public string? FilterText { get; set; }
}
