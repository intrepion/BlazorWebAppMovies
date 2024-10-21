namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

public class EntityNamePlaceholderAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder

    public static EntityNamePlaceholderAdminDto FromEntityNamePlaceholder(EntityNamePlaceholder? movie)
    {
        if (movie == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = movie.Id,

            // EntityToDtoPlaceholder
        };
    }

    public static EntityNamePlaceholder ToEntityNamePlaceholder(ApplicationUser? applicationUser, EntityNamePlaceholderAdminDto? movieAdminDto)
    {
        return new EntityNamePlaceholder
        {
            ApplicationUserUpdatedBy = applicationUser ?? new ApplicationUser(),
            Id = movieAdminDto?.Id ?? new Guid(),

            // DtoToEntityPropertyPlaceholder
        };
    }
}
