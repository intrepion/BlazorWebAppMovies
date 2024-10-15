using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class EntityNamePlaceholderAdminEditModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static EntityNamePlaceholderAdminEditModel FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto movieAdminDto)
    {
        if (movieAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditModel();
        }

        return new EntityNamePlaceholderAdminEditModel
        {
            Id = movieAdminDto.Id,

            // DtoToModelPlaceholder
            // Title = movieAdminDto.Title,
            // ToDoList = movieAdminDto.ToDoList,
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditModel movieAdminEditModel)
    {
        if (movieAdminEditModel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = movieAdminEditModel.Id,

            // ModelToDtoPlaceholder
            // Title = movieAdminEditModel.Title,
            // ToDoList = movieAdminEditModel.ToDoList,
        };
    }
}
