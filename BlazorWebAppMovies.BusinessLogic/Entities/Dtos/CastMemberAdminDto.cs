namespace BlazorWebAppMovies.BusinessLogic.Entities.Dtos;

public class CastMemberAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public string Name1 { get; set; } = string.Empty;
    public string Name2 { get; set; } = string.Empty;
    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static CastMemberAdminDto FromCastMember(CastMember? castMember)
    {
        if (castMember == null)
        {
            return new CastMemberAdminDto();
        }

        return new CastMemberAdminDto
        {
            Id = castMember.Id,

            Name1 = castMember.Name1,
            Name2 = castMember.Name2,
            // EntityToDtoPlaceholder
            // Title = castMember.Title,
            // ToDoList = castMember.ToDoList,
        };
    }

    public static CastMember ToCastMember(ApplicationUser applicationUser, CastMemberAdminDto castMemberAdminDto)
    {
        return new CastMember
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = castMemberAdminDto.Id,

            Name1 = castMemberAdminDto.Name1,
            Name2 = castMemberAdminDto.Name2,
            // DtoToEntityPropertyPlaceholder
            // Title = castMemberAdminDto.Title,
            // ToDoList = castMemberAdminDto.ToDoList,
        };
    }
}
