namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.CastMemberGrid;

public interface ICastMemberFilters
{
    CastMemberFilterColumns FilterColumn { get; set; }

    bool Loading { get; set; }

    string? FilterText { get; set; }

    IPageHelper PageHelper { get; set; }

    bool SortAscending { get; set; }

    CastMemberFilterColumns SortColumn { get; set; }
}
