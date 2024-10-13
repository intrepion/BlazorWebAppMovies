using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class MovieAdminEditModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static MovieAdminEditModel FromMovieAdminDto(MovieAdminDto movieAdminDto)
    {
        if (movieAdminDto == null)
        {
            return new MovieAdminEditModel();
        }

        return new MovieAdminEditModel
        {
            Id = movieAdminDto.Id,

            Title = movieAdminDto.Title,
            // DtoToModelPlaceholder
            // Title = movieAdminDto.Title,
            // ToDoList = movieAdminDto.ToDoList,
        };
    }

    public static MovieAdminDto ToMovieAdminDto(MovieAdminEditModel movieAdminEditModel)
    {
        if (movieAdminEditModel == null)
        {
            return new MovieAdminDto();
        }

        return new MovieAdminDto
        {
            Id = movieAdminEditModel.Id,

            // ModelToDtoPlaceholder
            // Title = movieAdminEditModel.Title,
            // ToDoList = movieAdminEditModel.ToDoList,
        };
    }
}
