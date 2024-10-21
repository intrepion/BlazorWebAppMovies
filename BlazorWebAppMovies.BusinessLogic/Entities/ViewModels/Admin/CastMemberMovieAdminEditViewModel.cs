using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class CastMemberMovieAdminEditViewModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder

    public static CastMemberMovieAdminEditViewModel FromCastMemberMovieAdminDto(CastMemberMovieAdminDto castMemberMovieAdminDto)
    {
        if (castMemberMovieAdminDto == null)
        {
            return new CastMemberMovieAdminEditViewModel();
        }

        return new CastMemberMovieAdminEditViewModel
        {
            Id = castMemberMovieAdminDto.Id,

            // DtoToModelPlaceholder
        };
    }

    public static CastMemberMovieAdminDto ToCastMemberMovieAdminDto(CastMemberMovieAdminEditViewModel castMemberMovieAdminEditViewModel)
    {
        if (castMemberMovieAdminEditViewModel == null)
        {
            return new CastMemberMovieAdminDto();
        }

        return new CastMemberMovieAdminDto
        {
            Id = castMemberMovieAdminEditViewModel.Id,

            // ModelToDtoPlaceholder
        };
    }
}
