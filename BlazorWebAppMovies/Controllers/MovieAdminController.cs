using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;
using ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationNamePlaceholder.Controllers;

[Route("api/admin/[controller]")]
[ApiController]
public class MovieController(IMovieAdminRepository movieAdminRepository) : ControllerBase
{
    private readonly IMovieAdminRepository _movieAdminRepository = movieAdminRepository;

    [HttpPost]
    public async Task<ActionResult<MovieAdminDto?>> Add(MovieAdminDto movieAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(movieAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseMovieAdminDto = await _movieAdminRepository.AddAsync(movieAdminDto);

        return Ok(databaseMovieAdminDto);
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

        var result = await _movieAdminRepository.DeleteAsync(userIdentityName, id);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<MovieAdminDto?>> Edit(MovieAdminDto movieAdminDto)
    {
        var userIdentityName = User.Identity?.Name;

        if (string.IsNullOrWhiteSpace(userIdentityName))
        {
            return Ok(null);
        }

        if (string.Equals(movieAdminDto.ApplicationUserName, userIdentityName, StringComparison.InvariantCultureIgnoreCase))
        {
            return Ok(null);
        }

        var databaseMovie = await _movieAdminRepository.EditAsync(movieAdminDto);

        return Ok(databaseMovie);
    }

    [HttpGet]
    public async Task<ActionResult<MovieAdminDto>?> GetAll(string userName)
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

        var movieAdminDtos = await _movieAdminRepository.GetAllAsync(userIdentityName);

        return Ok(movieAdminDtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieAdminDto?>> GetById(string userName, Guid id)
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

        var movieAdminDto = await _movieAdminRepository.GetByIdAsync(userIdentityName, id);

        return Ok(movieAdminDto);
    }
}
