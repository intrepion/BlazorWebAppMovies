namespace BlazorWebAppMovies.BusinessLogic.Entities.Dtos;

public class CastMemberMovieAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public CastMember? CastMember { get; set; }
    public Movie? Movie { get; set; }
    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static CastMemberMovieAdminDto FromCastMemberMovie(CastMemberMovie? castMemberMovie)
    {
        if (castMemberMovie == null)
        {
            return new CastMemberMovieAdminDto();
        }

        return new CastMemberMovieAdminDto
        {
            Id = castMemberMovie.Id,

            CastMember = castMemberMovie.CastMember,
            Movie = castMemberMovie.Movie,
            // EntityToDtoPlaceholder
            // Title = castMemberMovie.Title,
            // ToDoList = castMemberMovie.ToDoList,
        };
    }

    public static CastMemberMovie ToCastMemberMovie(ApplicationUser applicationUser, CastMemberMovieAdminDto castMemberMovieAdminDto)
    {
        return new CastMemberMovie
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = castMemberMovieAdminDto.Id,

            CastMember = castMemberMovieAdminDto.CastMember,
            Movie = castMemberMovieAdminDto.Movie,
            // DtoToEntityPropertyPlaceholder
            // Title = castMemberMovieAdminDto.Title,
            // ToDoList = castMemberMovieAdminDto.ToDoList,
        };
    }
}
