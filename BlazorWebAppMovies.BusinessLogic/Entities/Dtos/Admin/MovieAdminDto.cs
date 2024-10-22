namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

public class MovieAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder

    public static MovieAdminDto FromMovie(Movie? movie)
    {
        if (movie == null)
        {
            return new MovieAdminDto();
        }

        return new MovieAdminDto
        {
            Id = movie.Id,

            // EntityToDtoPlaceholder
        };
    }

    public static Movie ToMovie(ApplicationUser? applicationUser, MovieAdminDto? movieAdminDto)
    {
        return new Movie
        {
            ApplicationUserUpdatedBy = applicationUser ?? new ApplicationUser(),
            Id = movieAdminDto?.Id ?? new Guid(),

            // DtoToEntityPropertyPlaceholder
        };
    }
}
