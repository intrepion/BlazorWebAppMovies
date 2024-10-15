using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Server;

public class CastMemberAdminRepository(ApplicationDbContext applicationDbContext) : ICastMemberAdminRepository
{
    private readonly ApplicationDbContext _applicationDbContext = applicationDbContext;

    public async Task<CastMemberAdminDto?> AddAsync(CastMemberAdminDto castMemberAdminDto)
    {
        if (string.IsNullOrWhiteSpace(castMemberAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => castMemberAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        if (string.IsNullOrWhiteSpace(castMemberAdminDto.Name1))
        {
            throw new Exception("Name 1 required.");
        }

        // AddRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(castMemberAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        var castMember = CastMemberAdminDto.ToCastMember(user, castMemberAdminDto);

        castMember.NormalizedName1 = castMemberAdminDto.Name1.ToUpperInvariant();
        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.CastMembers.AddAsync(castMember);
        var databaseCastMemberAdminDto = CastMemberAdminDto.FromCastMember(result.Entity);
        await _applicationDbContext.SaveChangesAsync();

        return databaseCastMemberAdminDto;
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

        var databaseCastMember = await _applicationDbContext.CastMembers.FindAsync(id);

        if (databaseCastMember == null)
        {
            return false;
        }

        databaseCastMember.ApplicationUserUpdatedBy = user;
        await _applicationDbContext.SaveChangesAsync();

        _applicationDbContext.Remove(databaseCastMember);

        await _applicationDbContext.SaveChangesAsync();

        return true;
    }

    public async Task<CastMemberAdminDto?> EditAsync(CastMemberAdminDto castMemberAdminDto)
    {
        if (string.IsNullOrWhiteSpace(castMemberAdminDto.ApplicationUserName))
        {
            throw new Exception("UserName is required.");
        }

        var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => castMemberAdminDto.ApplicationUserName.ToUpper().Equals(x.NormalizedUserName));

        if (user == null)
        {
            throw new Exception("Authentication required.");
        }

        var databaseCastMember = await _applicationDbContext.CastMembers.FindAsync(castMemberAdminDto.Id);

        if (databaseCastMember == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        if (string.IsNullOrWhiteSpace(castMemberAdminDto.Name1))
        {
            throw new Exception("Name 1 required.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(castMemberAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseCastMember.ApplicationUserUpdatedBy = user;

        databaseCastMember.Name1 = castMemberAdminDto.Name1;
        databaseCastMember.NormalizedName1 = castMemberAdminDto.Name1.ToUpperInvariant();
        databaseCastMember.Name2 = castMemberAdminDto.Name2;
        // EditDatabasePropertyCodePlaceholder
        // databaseCastMember.Title = castMemberAdminDto.Title;
        // databaseCastMember.NormalizedTitle = castMemberAdminDto.Title.ToUpperInvariant();
        // databaseCastMember.ToDoList = castMemberAdminDto.ToDoList;

        await _applicationDbContext.SaveChangesAsync();

        return castMemberAdminDto;
    }

    public async Task<List<CastMember>?> GetAllAsync(string userName)
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

        return await _applicationDbContext.CastMembers

            .Include(x => x.CastMemberMovies)
    // IncludeTableCodePlaceholder

            .ToListAsync();
    }

    public async Task<CastMemberAdminDto?> GetByIdAsync(string userName, Guid id)
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

        var result = await _applicationDbContext.CastMembers.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return CastMemberAdminDto.FromCastMember(result);
    }
}
