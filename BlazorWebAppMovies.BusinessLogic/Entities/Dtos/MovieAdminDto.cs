namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class EntityNamePlaceholderAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static EntityNamePlaceholderAdminDto FromEntityNamePlaceholder(EntityNamePlaceholder? EntityLowercaseNamePlaceholder)
    {
        if (EntityLowercaseNamePlaceholder == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = EntityLowercaseNamePlaceholder.Id,

            // EntityToDtoPlaceholder
            // Title = EntityLowercaseNamePlaceholder.Title,
            // ToDoList = EntityLowercaseNamePlaceholder.ToDoList,
        };
    }

    public static EntityNamePlaceholder ToEntityNamePlaceholder(ApplicationUser applicationUser, EntityNamePlaceholderAdminDto EntityLowercaseNamePlaceholderAdminDto)
    {
        return new EntityNamePlaceholder
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = EntityLowercaseNamePlaceholderAdminDto.Id,

            // DtoToEntityPropertyPlaceholder
            // Title = EntityLowercaseNamePlaceholderAdminDto.Title,
            // ToDoList = EntityLowercaseNamePlaceholderAdminDto.ToDoList,
        };
    }
}
