using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Services;

public interface ICastMemberMovieAdminService
{
    Task<CastMemberMovieAdminDto?> AddAsync(CastMemberMovieAdminDto castMemberMovie);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<CastMemberMovieAdminDto?> EditAsync(CastMemberMovieAdminDto castMemberMovie);
    Task<List<CastMemberMovie>?> GetAllAsync(string userName);
    Task<CastMemberMovieAdminDto?> GetByIdAsync(string userName, Guid id);
}
