using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class MovieAdminEditViewModel
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    // JustModelPropertyPlaceholder

    public static MovieAdminEditViewModel FromMovieAdminDto(MovieAdminDto movieAdminDto)
    {
        if (movieAdminDto == null)
        {
            return new MovieAdminEditViewModel();
        }

        return new MovieAdminEditViewModel
        {
            Id = movieAdminDto.Id,

            Title = movieAdminDto.Title,
            // DtoToModelPlaceholder
        };
    }

    public static MovieAdminDto ToMovieAdminDto(MovieAdminEditViewModel movieAdminEditViewModel)
    {
        if (movieAdminEditViewModel == null)
        {
            return new MovieAdminDto();
        }

        return new MovieAdminDto
        {
            Id = movieAdminEditViewModel.Id,

            Title = movieAdminEditViewModel.Title,
            // ModelToDtoPlaceholder
        };
    }
}
