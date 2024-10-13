namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class MovieAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

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
            // Title = movie.Title,
            // ToDoList = movie.ToDoList,
        };
    }

    public static Movie ToMovie(ApplicationUser applicationUser, MovieAdminDto movieAdminDto)
    {
        return new Movie
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = movieAdminDto.Id,

            // DtoToEntityPropertyPlaceholder
            // Title = movieAdminDto.Title,
            // ToDoList = movieAdminDto.ToDoList,
        };
    }
}
