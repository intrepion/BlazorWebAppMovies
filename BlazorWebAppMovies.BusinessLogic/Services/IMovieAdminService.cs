using BlazorWebAppMovies.BusinessLogic.Entities;
using BlazorWebAppMovies.BusinessLogic.Entities.Dtos;

namespace BlazorWebAppMovies.BusinessLogic.Services;

public interface IMovieAdminService
{
    Task<MovieAdminDto?> AddAsync(MovieAdminDto movie);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<MovieAdminDto?> EditAsync(MovieAdminDto movie);
    Task<List<Movie>?> GetAllAsync(string userName);
    Task<MovieAdminDto?> GetByIdAsync(string userName, Guid id);
}
