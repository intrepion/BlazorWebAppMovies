using BlazorWebAppMovies.BusinessLogic.Entities.Dtos;
using BlazorWebAppMovies.BusinessLogic.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAppMovies.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class CastMemberMovieController(ICastMemberMovieAdminRepository castMemberMovieAdminRepository) : ControllerBase
{
    private readonly ICastMemberMovieAdminRepository _castMemberMovieAdminRepository = castMemberMovieAdminRepository;

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

        var databaseCastMemberMovieAdminDto = await _castMemberMovieAdminRepository.AddAsync(castMemberMovieAdminDto);

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

        var result = await _castMemberMovieAdminRepository.DeleteAsync(userIdentityName, id);

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

        var databaseCastMemberMovie = await _castMemberMovieAdminRepository.EditAsync(castMemberMovieAdminDto);

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

        var castMemberMovieAdminDtos = await _castMemberMovieAdminRepository.GetAllAsync(userIdentityName);

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

        var castMemberMovieAdminDto = await _castMemberMovieAdminRepository.GetByIdAsync(userIdentityName, id);

        return Ok(castMemberMovieAdminDto);
    }
}
