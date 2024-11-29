namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.MovieGrid;

public class MovieGridControls(IPageHelper pageHelper) : IMovieFilters
{
    public IPageHelper PageHelper { get; set; } = pageHelper;

    public bool Loading { get; set; }

    public MovieFilterColumns SortColumn { get; set; } = MovieFilterColumns.Id;

    public bool SortAscending { get; set; } = true;

    public MovieFilterColumns FilterColumn { get; set; } = MovieFilterColumns.Id;

    public string? FilterText { get; set; }
}
