using BlazorWebAppMovies.BusinessLogic.Entities.Dtos.Admin;

namespace BlazorWebAppMovies.BusinessLogic.Repositories.Admin;

public interface IMovieAdminRepository
{
    Task<MovieAdminDto?> AddAsync(MovieAdminDto movie);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<MovieAdminDto?> EditAsync(MovieAdminDto movie);
    Task<List<MovieAdminDto>?> GetAllAsync(string userName);
    Task<MovieAdminDto?> GetByIdAsync(string userName, Guid id);
}
