namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.CastMemberGrid;

public class CastMemberGridControls(IPageHelper pageHelper) : ICastMemberFilters
{
    public IPageHelper PageHelper { get; set; } = pageHelper;

    public bool Loading { get; set; }

    public CastMemberFilterColumns SortColumn { get; set; } = CastMemberFilterColumns.Id;

    public bool SortAscending { get; set; } = true;

    public CastMemberFilterColumns FilterColumn { get; set; } = CastMemberFilterColumns.Id;

    public string? FilterText { get; set; }
}
