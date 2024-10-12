using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using ApplicationNamePlaceholder.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class CastMemberController(ICastMemberAdminService castMemberAdminService) : ControllerBase
{
    private readonly ICastMemberAdminService _castMemberAdminService = castMemberAdminService;

    [HttpPost]
    public async Task<ActionResult<CastMemberAdminDto?>> Add(CastMemberAdminDto castMemberAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(castMemberAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseCastMemberAdminDto = await _castMemberAdminService.AddAsync(castMemberAdminDto);

        return Ok(databaseCastMemberAdminDto);
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

        var result = await _castMemberAdminService.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<CastMemberAdminDto?>> Edit(CastMemberAdminDto castMemberAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(castMemberAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseCastMember = await _castMemberAdminService.EditAsync(castMemberAdminDto);

        return Ok(databaseCastMember);
    }

    [HttpGet]
    public async Task<ActionResult<CastMemberAdminDto>?> GetAll(string userName)
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

        var castMemberAdminDtos = await _castMemberAdminService.GetAllAsync(userIdentityName);

        return Ok(castMemberAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CastMemberAdminDto?>> GetById(string userName, Guid id)
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

        var castMemberAdminDto = await _castMemberAdminService.GetByIdAsync(userIdentityName, id);

        return Ok(castMemberAdminDto);
    }
}
