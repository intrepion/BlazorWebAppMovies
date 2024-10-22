using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class CastMemberAdminEditViewModel
{
    public Guid Id { get; set; }

    public string Name1 { get; set; } = string.Empty;
    public string Name2 { get; set; } = string.Empty;
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

            Name1 = castMemberAdminDto?.Name1 ?? string.Empty,
            Name2 = castMemberAdminDto?.Name2 ?? string.Empty,
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

            Name1 = castMemberAdminEditViewModel.Name1,
            // ModelToDtoPlaceholder
        };
    }
}
