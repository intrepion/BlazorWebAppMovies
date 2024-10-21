﻿using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin.Server;

public class MovieAdminRepository(ApplicationDbContext applicationDbContext) : IMovieAdminRepository
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

        var movie = MovieAdminDto.ToMovie(user, movieAdminDto);

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

        databaseMovie.ApplicationUserUpdatedBy = user;

        // EditDatabasePropertyCodePlaceholder

        await _applicationDbContext.SaveChangesAsync();

        return movieAdminDto;
    }

    public async Task<List<MovieAdminDto>?> GetAllAsync(string userName)
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

            .Include(x => x.MovieCastMembers)
            // IncludeTableCodePlaceholder

            .Select(x => MovieAdminDto.FromMovie(x))
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
