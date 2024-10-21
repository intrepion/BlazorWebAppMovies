using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Admin;

public interface ICastMemberMovieAdminRepository
{
    Task<CastMemberMovieAdminDto?> AddAsync(CastMemberMovieAdminDto castMemberMovie);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<CastMemberMovieAdminDto?> EditAsync(CastMemberMovieAdminDto castMemberMovie);
    Task<List<CastMemberMovieAdminDto>?> GetAllAsync(string userName);
    Task<CastMemberMovieAdminDto?> GetByIdAsync(string userName, Guid id);
}
