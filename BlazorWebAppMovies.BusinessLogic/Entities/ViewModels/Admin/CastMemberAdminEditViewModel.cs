using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class CastMemberAdminEditViewModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder

    public static CastMemberAdminEditViewModel FromCastMemberAdminDto(CastMemberAdminDto castMemberAdminDto)
    {
        if (castMemberAdminDto == null)
        {
            return new CastMemberAdminEditViewModel();
        }

        return new CastMemberAdminEditViewModel
        {
            Id = castMemberAdminDto.Id,

            // DtoToModelPlaceholder
        };
    }

    public static CastMemberAdminDto ToCastMemberAdminDto(CastMemberAdminEditViewModel castMemberAdminEditViewModel)
    {
        if (castMemberAdminEditViewModel == null)
        {
            return new CastMemberAdminDto();
        }

        return new CastMemberAdminDto
        {
            Id = castMemberAdminEditViewModel.Id,

            // ModelToDtoPlaceholder
        };
    }
}
