using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class CastMemberMovieAdminEditViewModel
{
    public Guid Id { get; set; }

    public CastMember? CastMember { get; set; }
    public Movie? Movie { get; set; }
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

            CastMember = castMemberMovieAdminDto?.CastMember,
            Movie = castMemberMovieAdminDto?.Movie,
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

            CastMember = castMemberMovieAdminEditViewModel.CastMember,
            // ModelToDtoPlaceholder
        };
    }
}
