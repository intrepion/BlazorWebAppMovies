using BlazorWebAppMovies.BusinessLogic.Data;
using BlazorWebAppMovies.BusinessLogic.Entities;
using BlazorWebAppMovies.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.BusinessLogic.Services.Server;

public class CastMemberMovieAdminService(ApplicationDbContext applicationDbContext) : ICastMemberMovieAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<CastMemberMovieAdminDto?> AddAsync(CastMemberMovieAdminDto castMemberMovieAdminDto)
    {
        if (string.IsNullOrWhiteSpace(castMemberMovieAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => castMemberMovieAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        // AddRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(castMemberMovieAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        var castMemberMovie = CastMemberMovieAdminDto.ToCastMemberMovie(user, castMemberMovieAdminDto);

        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.CastMemberMovies.AddAsync(castMemberMovie);
        var databaseCastMemberMovieAdminDto = CastMemberMovieAdminDto.FromCastMemberMovie(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseCastMemberMovieAdminDto;
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseCastMemberMovie = await _applicationDbContext.CastMemberMovies.FindAsync(id);

        if (databaseCastMemberMovie == null)
        {
            return false;
        }

        databaseCastMemberMovie.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseCastMemberMovie);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<CastMemberMovieAdminDto?> EditAsync(CastMemberMovieAdminDto castMemberMovieAdminDto)
    {
        if (string.IsNullOrWhiteSpace(castMemberMovieAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => castMemberMovieAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseCastMemberMovie = await _applicationDbContext.CastMemberMovies.FindAsync(castMemberMovieAdminDto.Id);

        if (databaseCastMemberMovie == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(castMemberMovieAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseCastMemberMovie.ApplicationUserUpdatedBy = user;

        databaseCastMemberMovie.CastMember = castMemberMovieAdminDto.CastMember;
        databaseCastMemberMovie.Movie = castMemberMovieAdminDto.Movie;
        // EditDatabasePropertyCodePlaceholder
        // databaseCastMemberMovie.Title = castMemberMovieAdminDto.Title;
        // databaseCastMemberMovie.NormalizedTitle = castMemberMovieAdminDto.Title.ToUpperInvariant();
        // databaseCastMemberMovie.ToDoList = castMemberMovieAdminDto.ToDoList;

        await _applicationDbContext.SaveChangesAsync();

        return castMemberMovieAdminDto;
    }

    public async Task<List<CastMemberMovie>?> GetAllAsync(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        return await _applicationDbContext.CastMemberMovies

            // IncludeTableCodePlaceholder

            .ToListAsync();
    }

    public async Task<CastMemberMovieAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => userName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var result = await _applicationDbContext.CastMemberMovies.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return CastMemberMovieAdminDto.FromCastMemberMovie(result);
    }
}
