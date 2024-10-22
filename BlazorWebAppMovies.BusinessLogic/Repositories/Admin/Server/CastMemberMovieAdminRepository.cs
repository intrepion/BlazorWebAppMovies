using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin.Server;

public class CastMemberMovieAdminRepository(ApplicationDbContext applicationDbContext) : ICastMemberMovieAdminRepository
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

        databaseCastMemberMovie.ApplicationUserUpdatedBy = user;

        databaseCastMemberMovie.CastMember = castMemberMovieAdminDto?.CastMember;
        // EditDatabasePropertyCodePlaceholder

        await _applicationDbContext.SaveChangesAsync();

        return castMemberMovieAdminDto;
    }

    public async Task<List<CastMemberMovieAdminDto>?> GetAllAsync(string userName)
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

            .Select(x => CastMemberMovieAdminDto.FromCastMemberMovie(x))
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
