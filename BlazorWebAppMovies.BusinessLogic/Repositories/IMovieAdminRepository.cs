using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories;

public interface IMovieAdminRepository
{
    Task<MovieAdminDto?> AddAsync(MovieAdminDto movie);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<MovieAdminDto?> EditAsync(MovieAdminDto movie);
    Task<List<Movie>?> GetAllAsync(string userName);
    Task<MovieAdminDto?> GetByIdAsync(string userName, Guid id);
}
