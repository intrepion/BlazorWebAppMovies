namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.CastMemberMovieGrid;

public interface ICastMemberMovieFilters
{
    CastMemberMovieFilterColumns FilterColumn { get; set; }

    bool Loading { get; set; }

    string? FilterText { get; set; }

    IPageHelper PageHelper { get; set; }

    bool SortAscending { get; set; }

    CastMemberMovieFilterColumns SortColumn { get; set; }
}
