namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.MovieGrid;

public interface IMovieFilters
{
    MovieFilterColumns FilterColumn { get; set; }

    bool Loading { get; set; }

    string? FilterText { get; set; }

    IPageHelper PageHelper { get; set; }

    bool SortAscending { get; set; }

    MovieFilterColumns SortColumn { get; set; }
}
