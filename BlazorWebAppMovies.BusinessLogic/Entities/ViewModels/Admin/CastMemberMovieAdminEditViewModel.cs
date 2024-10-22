using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.ViewModels.Admin;

public class EntityNamePlaceholderAdminEditViewModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder

    public static EntityNamePlaceholderAdminEditViewModel FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto castMemberMovieAdminDto)
    {
        if (castMemberMovieAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditViewModel();
        }

        return new EntityNamePlaceholderAdminEditViewModel
        {
            Id = castMemberMovieAdminDto.Id,

            // DtoToModelPlaceholder
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditViewModel castMemberMovieAdminEditViewModel)
    {
        if (castMemberMovieAdminEditViewModel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = castMemberMovieAdminEditViewModel.Id,

            // ModelToDtoPlaceholder
        };
    }
}
