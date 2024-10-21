using BlazorWebAppMovies.BusinessLogic.Entities.Dtos.Admin;

namespace BlazorWebAppMovies.BusinessLogic.Repositories.Admin;

public interface ICastMemberAdminRepository
{
    Task<CastMemberAdminDto?> AddAsync(CastMemberAdminDto castMember);
    Task<bool> DeleteAsync(string userName, Guid id);
    Task<CastMemberAdminDto?> EditAsync(CastMemberAdminDto castMember);
    Task<List<CastMemberAdminDto>?> GetAllAsync(string userName);
    Task<CastMemberAdminDto?> GetByIdAsync(string userName, Guid id);
}
