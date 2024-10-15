using BlazorWebAppMovies.BusinessLogic.Entities;
using BlazorWebAppMovies.BusinessLogic.Entities.Dtos;

namespace BlazorWebAppMovies.BusinessLogic.Repositories;

public interface ICastMemberAdminRepository
{
    Task<CastMemberAdminDto?> AddAsync(CastMemberAdminDto castMember);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<CastMemberAdminDto?> EditAsync(CastMemberAdminDto castMember);
    Task<List<CastMember>?> GetAllAsync(string userName);
    Task<CastMemberAdminDto?> GetByIdAsync(string userName, Guid id);
}
