using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class ApplicationRoleAdminEditModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public static ApplicationRoleAdminEditModel FromApplicationRoleAdminDto(ApplicationRoleAdminDto? applicationRoleAdminDto)
    {
        if (applicationRoleAdminDto == null)
        {
            return new ApplicationRoleAdminEditModel();
        }

        return new ApplicationRoleAdminEditModel
        {
            Id = applicationRoleAdminDto.Id,
            Name = applicationRoleAdminDto.Name,
        };
    }

    public static ApplicationRoleAdminDto ToApplicationRoleAdminDto(ApplicationRoleAdminEditModel? applicationRoleAdminEditModel)
    {
        if (applicationRoleAdminEditModel == null)
        {
            return new ApplicationRoleAdminDto();
        }

        return new ApplicationRoleAdminDto
        {
            Id = applicationRoleAdminEditModel.Id,
            Name = applicationRoleAdminEditModel.Name,
        };
    }
}
