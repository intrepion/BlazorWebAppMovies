using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface IEntityNamePlaceholderAdminService
{
    Task<EntityNamePlaceholderAdminDto?> AddAsync(EntityNamePlaceholderAdminDto EntityLowercaseNamePlaceholder);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<EntityNamePlaceholderAdminDto?> EditAsync(EntityNamePlaceholderAdminDto EntityLowercaseNamePlaceholder);
    Task<List<EntityNamePlaceholder>?> GetAllAsync(string userName);
    Task<EntityNamePlaceholderAdminDto?> GetByIdAsync(string userName, Guid id);
}
