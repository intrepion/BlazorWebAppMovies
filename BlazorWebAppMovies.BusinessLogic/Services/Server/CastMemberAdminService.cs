using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Server;

public class CastMemberAdminService(ApplicationDbContext applicationDbContext) : ICastMemberAdminService
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

        // AddRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(castMemberAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        var castMember = CastMemberAdminDto.ToCastMember(user, castMemberAdminDto);

        // AddDatabasePropertyCodePlaceholder

        var result = await _applicationDbContext.TableNamePlaceholder.AddAsync(castMember);
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

        var databaseCastMember = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

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

        var databaseCastMember = await _applicationDbContext.TableNamePlaceholder.FindAsync(castMemberAdminDto.Id);

        if (databaseCastMember == null)
        {
            throw new Exception("HumanNamePlaceholder not found.");
        }

        // EditRequiredPropertyCodePlaceholder
        // if (string.IsNullOrWhiteSpace(castMemberAdminDto.Title))
        // {
        //     throw new Exception("Title required.");
        // }

        databaseCastMember.ApplicationUserUpdatedBy = user;

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

        return await _applicationDbContext.TableNamePlaceholder

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

        var result = await _applicationDbContext.TableNamePlaceholder.FindAsync(id);

        if (result == null)
        {
            return null;
        }

        return CastMemberAdminDto.FromCastMember(result);
    }
}
