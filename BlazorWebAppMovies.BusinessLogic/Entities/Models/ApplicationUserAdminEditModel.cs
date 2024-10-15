using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class ApplicationUserAdminEditModel
{
    public List<ApplicationRole> ApplicationRoles { get; set; } = [];
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;

    public static ApplicationUserAdminEditModel FromApplicationUserAdminDto(ApplicationUserAdminDto applicationUserAdminDto)
    {
        if (applicationUserAdminDto == null)
        {
            return new ApplicationUserAdminEditModel();
        }

        var applicationUserAdminEditModel = new ApplicationUserAdminEditModel
        {
            ApplicationRoles = applicationUserAdminDto.ApplicationRoles,
            Email = applicationUserAdminDto.Email,
            Id = applicationUserAdminDto.Id,
            PhoneNumber = applicationUserAdminDto.PhoneNumber,
            UserName = applicationUserAdminDto.UserName,
        };

        return applicationUserAdminEditModel;
    }

    public static ApplicationUserAdminDto ToApplicationUserAdminDto(ApplicationUserAdminEditModel? applicationUserAdminEditModel)
    {
        if (applicationUserAdminEditModel == null)
        {
            return new ApplicationUserAdminDto();
        }

        var applicationUserAdminDto = new ApplicationUserAdminDto
        {
            ApplicationRoles = applicationUserAdminEditModel.ApplicationRoles,
            Email = applicationUserAdminEditModel.Email,
            Id = applicationUserAdminEditModel.Id,
            PhoneNumber = applicationUserAdminEditModel.PhoneNumber,
            UserName = applicationUserAdminEditModel.UserName,
        };

        return applicationUserAdminDto;
    }
}
