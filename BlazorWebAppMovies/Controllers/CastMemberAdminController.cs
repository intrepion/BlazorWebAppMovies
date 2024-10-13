using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class EntityNamePlaceholderController(IEntityNamePlaceholderAdminService EntityLowercaseNamePlaceholderAdminService) : ControllerBase
{
    private readonly IEntityNamePlaceholderAdminService _EntityLowercaseNamePlaceholderAdminService = EntityLowercaseNamePlaceholderAdminService;

    [HttpPost]
    public async Task<ActionResult<EntityNamePlaceholderAdminDto?>> Add(EntityNamePlaceholderAdminDto EntityLowercaseNamePlaceholderAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(EntityLowercaseNamePlaceholderAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseEntityNamePlaceholderAdminDto = await _EntityLowercaseNamePlaceholderAdminService.AddAsync(EntityLowercaseNamePlaceholderAdminDto);

        return Ok(databaseEntityNamePlaceholderAdminDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool?>> Delete(string userName, Guid id)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(userName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var result = await _EntityLowercaseNamePlaceholderAdminService.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<EntityNamePlaceholderAdminDto?>> Edit(EntityNamePlaceholderAdminDto EntityLowercaseNamePlaceholderAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(EntityLowercaseNamePlaceholderAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseEntityNamePlaceholder = await _EntityLowercaseNamePlaceholderAdminService.EditAsync(EntityLowercaseNamePlaceholderAdminDto);

        return Ok(databaseEntityNamePlaceholder);
    }

    [HttpGet]
    public async Task<ActionResult<EntityNamePlaceholderAdminDto>?> GetAll(string userName)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(userName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var EntityLowercaseNamePlaceholderAdminDtos = await _EntityLowercaseNamePlaceholderAdminService.GetAllAsync(userIdentityName);

        return Ok(EntityLowercaseNamePlaceholderAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EntityNamePlaceholderAdminDto?>> GetById(string userName, Guid id)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(userName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var EntityLowercaseNamePlaceholderAdminDto = await _EntityLowercaseNamePlaceholderAdminService.GetByIdAsync(userIdentityName, id);

        return Ok(EntityLowercaseNamePlaceholderAdminDto);
    }
}
