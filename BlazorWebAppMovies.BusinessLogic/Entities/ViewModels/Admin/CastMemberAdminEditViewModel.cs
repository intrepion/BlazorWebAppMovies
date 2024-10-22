using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class EntityNamePlaceholderAdminEditViewModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder

    public static EntityNamePlaceholderAdminEditViewModel FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto castMemberAdminDto)
    {
        if (castMemberAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditViewModel();
        }

        return new EntityNamePlaceholderAdminEditViewModel
        {
            Id = castMemberAdminDto.Id,

            // DtoToModelPlaceholder
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditViewModel castMemberAdminEditViewModel)
    {
        if (castMemberAdminEditViewModel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = castMemberAdminEditViewModel.Id,

            // ModelToDtoPlaceholder
        };
    }
}
