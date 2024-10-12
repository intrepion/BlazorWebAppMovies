using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class EntityNamePlaceholderAdminEditModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static EntityNamePlaceholderAdminEditModel FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto castMemberMovieAdminDto)
    {
        if (castMemberMovieAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditModel();
        }

        return new EntityNamePlaceholderAdminEditModel
        {
            Id = castMemberMovieAdminDto.Id,

            // DtoToModelPlaceholder
            // Title = castMemberMovieAdminDto.Title,
            // ToDoList = castMemberMovieAdminDto.ToDoList,
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditModel castMemberMovieAdminEditModel)
    {
        if (castMemberMovieAdminEditModel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = castMemberMovieAdminEditModel.Id,

            // ModelToDtoPlaceholder
            // Title = castMemberMovieAdminEditModel.Title,
            // ToDoList = castMemberMovieAdminEditModel.ToDoList,
        };
    }
}
