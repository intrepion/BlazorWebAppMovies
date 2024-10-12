using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class CastMemberAdminEditModel
{
    public Guid Id { get; set; }

    public string Name1 { get; set; } = string.Empty;
    public string Name2 { get; set; } = string.Empty;
    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static CastMemberAdminEditModel FromCastMemberAdminDto(CastMemberAdminDto castMemberAdminDto)
    {
        if (castMemberAdminDto == null)
        {
            return new CastMemberAdminEditModel();
        }

        return new CastMemberAdminEditModel
        {
            Id = castMemberAdminDto.Id,

            Name1 = castMemberAdminDto.Name1,
            Name2 = castMemberAdminDto.Name2,
            // DtoToModelPlaceholder
            // Title = castMemberAdminDto.Title,
            // ToDoList = castMemberAdminDto.ToDoList,
        };
    }

    public static CastMemberAdminDto ToCastMemberAdminDto(CastMemberAdminEditModel castMemberAdminEditModel)
    {
        if (castMemberAdminEditModel == null)
        {
            return new CastMemberAdminDto();
        }

        return new CastMemberAdminDto
        {
            Id = castMemberAdminEditModel.Id,

            Name1 = castMemberAdminEditModel.Name1,
            // ModelToDtoPlaceholder
            // Title = castMemberAdminEditModel.Title,
            // ToDoList = castMemberAdminEditModel.ToDoList,
        };
    }
}
