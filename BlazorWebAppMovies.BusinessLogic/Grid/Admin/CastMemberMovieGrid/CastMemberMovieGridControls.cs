namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.CastMemberMovieGrid;

public class CastMemberMovieGridControls(IPageHelper pageHelper) : ICastMemberMovieFilters
{
    public IPageHelper PageHelper { get; set; } = pageHelper;

    public bool Loading { get; set; }

    public CastMemberMovieFilterColumns SortColumn { get; set; } = CastMemberMovieFilterColumns.Id;

    public bool SortAscending { get; set; } = true;

    public CastMemberMovieFilterColumns FilterColumn { get; set; } = CastMemberMovieFilterColumns.Id;

    public string? FilterText { get; set; }
}
