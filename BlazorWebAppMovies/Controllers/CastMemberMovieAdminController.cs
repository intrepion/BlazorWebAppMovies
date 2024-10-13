using BlazorWebAppMovies.BusinessLogic.Entities.Dtos;
using BlazorWebAppMovies.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAppMovies.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class CastMemberMovieController(ICastMemberMovieAdminService castMemberMovieAdminService) : ControllerBase
{
    private readonly ICastMemberMovieAdminService _castMemberMovieAdminService = castMemberMovieAdminService;

    [HttpPost]
    public async Task<ActionResult<CastMemberMovieAdminDto?>> Add(CastMemberMovieAdminDto castMemberMovieAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(castMemberMovieAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseCastMemberMovieAdminDto = await _castMemberMovieAdminService.AddAsync(castMemberMovieAdminDto);

        return Ok(databaseCastMemberMovieAdminDto);
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

        var result = await _castMemberMovieAdminService.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<CastMemberMovieAdminDto?>> Edit(CastMemberMovieAdminDto castMemberMovieAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(castMemberMovieAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseCastMemberMovie = await _castMemberMovieAdminService.EditAsync(castMemberMovieAdminDto);

        return Ok(databaseCastMemberMovie);
    }

    [HttpGet]
    public async Task<ActionResult<CastMemberMovieAdminDto>?> GetAll(string userName)
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

        var castMemberMovieAdminDtos = await _castMemberMovieAdminService.GetAllAsync(userIdentityName);

        return Ok(castMemberMovieAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CastMemberMovieAdminDto?>> GetById(string userName, Guid id)
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

        var castMemberMovieAdminDto = await _castMemberMovieAdminService.GetByIdAsync(userIdentityName, id);

        return Ok(castMemberMovieAdminDto);
    }
}
