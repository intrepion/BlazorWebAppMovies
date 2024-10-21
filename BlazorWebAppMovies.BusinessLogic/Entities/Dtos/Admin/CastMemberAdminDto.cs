namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

public class CastMemberAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

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

            // EntityToDtoPlaceholder
        };
    }

    public static CastMember ToCastMember(ApplicationUser? applicationUser, CastMemberAdminDto? castMemberAdminDto)
    {
        return new CastMember
        {
            ApplicationUserUpdatedBy = applicationUser ?? new ApplicationUser(),
            Id = castMemberAdminDto?.Id ?? new Guid(),

            // DtoToEntityPropertyPlaceholder
        };
    }
}
