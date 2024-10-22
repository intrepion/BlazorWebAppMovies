using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class MovieAdminEditViewModel
{
    public Guid Id { get; set; }

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

            // ModelToDtoPlaceholder
        };
    }
}
