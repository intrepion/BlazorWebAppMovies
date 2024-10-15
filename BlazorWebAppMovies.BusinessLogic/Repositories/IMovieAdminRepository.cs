﻿using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories;

public interface IEntityNamePlaceholderAdminRepository
{
    Task<EntityNamePlaceholderAdminDto?> AddAsync(EntityNamePlaceholderAdminDto movie);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<EntityNamePlaceholderAdminDto?> EditAsync(EntityNamePlaceholderAdminDto movie);
    Task<List<EntityNamePlaceholder>?> GetAllAsync(string userName);
    Task<EntityNamePlaceholderAdminDto?> GetByIdAsync(string userName, Guid id);
}
