using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class EntityNamePlaceholderAdminEditModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static EntityNamePlaceholderAdminEditModel FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto castMemberAdminDto)
    {
        if (castMemberAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditModel();
        }

        return new EntityNamePlaceholderAdminEditModel
        {
            Id = castMemberAdminDto.Id,

            // DtoToModelPlaceholder
            // Title = castMemberAdminDto.Title,
            // ToDoList = castMemberAdminDto.ToDoList,
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditModel castMemberAdminEditModel)
    {
        if (castMemberAdminEditModel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = castMemberAdminEditModel.Id,

            // ModelToDtoPlaceholder
            // Title = castMemberAdminEditModel.Title,
            // ToDoList = castMemberAdminEditModel.ToDoList,
        };
    }
}
