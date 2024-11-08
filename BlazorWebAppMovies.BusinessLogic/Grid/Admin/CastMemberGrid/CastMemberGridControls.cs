namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.CastMemberGrid;

// State of grid filters.
public class CastMemberGridControls(IPageHelper pageHelper) : ICastMemberFilters
{
    // Keep state of paging.
    public IPageHelper PageHelper { get; set; } = pageHelper;

    // Avoid multiple concurrent requests.
    public bool Loading { get; set; }

    // Column to sort by.
    public CastMemberFilterColumns SortColumn { get; set; } = CastMemberFilterColumns.Id;

    // True when sorting ascending, otherwise sort descending.
    public bool SortAscending { get; set; } = true;

    // Column filtered text is against.
    public CastMemberFilterColumns FilterColumn { get; set; } = CastMemberFilterColumns.Id;

    // Text to filter on.
    public string? FilterText { get; set; }
}
