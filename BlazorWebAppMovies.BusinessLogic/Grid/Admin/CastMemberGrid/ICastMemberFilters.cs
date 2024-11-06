namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.CastMemberGrid;

// Interface for filtering.
public interface ICastMemberFilters
{
    // The CastMemberFilterColumns being filtered on.
    CastMemberFilterColumns FilterColumn { get; set; }

    // Loading indicator.
    bool Loading { get; set; }

    // The text of the filter.
    string? FilterText { get; set; }

    // Paging state in PageHelper.
    IPageHelper PageHelper { get; set; }

    // Gets or sets a value indicating if the sort is ascending or descending.
    bool SortAscending { get; set; }

    // The CastMemberFilterColumns being sorted.
    CastMemberFilterColumns SortColumn { get; set; }
}
