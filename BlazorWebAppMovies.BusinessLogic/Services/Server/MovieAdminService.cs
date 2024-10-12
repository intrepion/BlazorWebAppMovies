using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class MovieAdminService(ApplicationDbContext applicationDbContext) : IMovieAdminService
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<MovieAdminDto?> AddAsync(MovieAdminDto movieAdminDto)
    {
        if (string.IsNullOrWhiteSpace(movieAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => movieAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        // AddRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(movieAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        var movie = MovieAdminDto.ToMovie(user, movieAdminDto);

        movie.NormalizedTitle = movieAdminDto.Title.ToUpperInvariant();
        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.Movies.AddAsync(movie);
        var databaseMovieAdminDto = MovieAdminDto.FromMovie(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseMovieAdminDto;
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

        var databaseMovie = await _applicationDbContext.Movies.FindAsync(id);

        if (databaseMovie == null)
        {
            return false;
        }

        databaseMovie.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseMovie);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<MovieAdminDto?> EditAsync(MovieAdminDto movieAdminDto)
    {
        if (string.IsNullOrWhiteSpace(movieAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => movieAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseMovie = await _applicationDbContext.Movies.FindAsync(movieAdminDto.Id);

        if (databaseMovie == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(movieAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseMovie.ApplicationUserUpdatedBy = user;

        databaseMovie.Title = movieAdminDto.Title;
        // EditDatabasePropertyCodePlaceholder
        // databaseMovie.Title = movieAdminDto.Title;
        // databaseMovie.NormalizedTitle = movieAdminDto.Title.ToUpperInvariant();
        // databaseMovie.ToDoList = movieAdminDto.ToDoList;

        await _applicationDbContext.SaveChangesAsync();

        return movieAdminDto;
    }

    public async Task<List<Movie>?> GetAllAsync(string userName)
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

        return await _applicationDbContext.Movies

            .Include(x => x.CastMemberMovies)
    // IncludeTableCodePlaceholder

            .ToListAsync();
    }

    public async Task<MovieAdminDto?> GetByIdAsync(string userName, Guid id)
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

        var result = await _applicationDbContext.Movies.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return MovieAdminDto.FromMovie(result);
    }
}
