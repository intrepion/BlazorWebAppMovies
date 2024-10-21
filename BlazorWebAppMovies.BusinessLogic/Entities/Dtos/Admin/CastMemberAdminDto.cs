namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

public class CastMemberAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public string Name1 { get; set; } = string.Empty;
    public string Name2 { get; set; } = string.Empty;
    // DtoPropertyPlaceholder

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
            // EntityToDtoPlaceholder
        };
    }

    public static CastMember ToCastMember(ApplicationUser? applicationUser, CastMemberAdminDto? castMemberAdminDto)
    {
        return new CastMember
        {
            ApplicationUserUpdatedBy = applicationUser ?? new ApplicationUser(),
            Id = castMemberAdminDto?.Id ?? new Guid(),

            Name1 = castMemberAdminDto.Name1,
            // DtoToEntityPropertyPlaceholder
        };
    }
}
