using BlazorWebAppMovies.BusinessLogic.Entities;
using BlazorWebAppMovies.BusinessLogic.Entities.Importers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorWebAppMovies.BusinessLogic.Data;

public static class DatabaseUtility
{
    public static async Task EnsureDbCreatedAndSeedAsync(
        IServiceProvider serviceProvider
    )
    {
        using var scope = serviceProvider.CreateScope();
        var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var isNewDatabase = await applicationDbContext.Database.EnsureCreatedAsync();

        var adminName = "Admin";
        var adminUserPass = adminName + "1@BlazorWebAppMovies.com";
        var adminNormalizedUserName = adminUserPass.ToUpperInvariant();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        if (isNewDatabase)
        {
            var adminUser = (await applicationDbContext.Users.AddAsync(new ApplicationUser
            {
                Email = adminUserPass,
                EmailConfirmed = true,
                NormalizedEmail = adminUserPass.ToUpperInvariant(),
                NormalizedUserName = adminUserPass.ToUpperInvariant(),
                UserName = adminUserPass,
            })).Entity;

            await userManager.AddPasswordAsync(adminUser, adminUserPass);

            var adminRole = (await applicationDbContext.Roles.AddAsync(new ApplicationRole
            {
                Name = adminName,
                NormalizedName = adminName.ToUpperInvariant(),
            })).Entity;

            adminRole.ApplicationUserUpdatedBy = adminUser;
            adminUser.ApplicationUserUpdatedBy = adminUser;
            _ = await applicationDbContext.UserRoles.AddAsync(new ApplicationUserRole
            {
                RoleId = adminRole.Id,
                UserId = adminUser.Id,
                ApplicationUserUpdatedBy = adminUser,
            });

            // ReadDataCodePlaceholder

            // await FakeData.SeedAsync(applicationDbContext, adminUser);

            await applicationDbContext.SaveChangesAsync();
        }

        var baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;

        var dataPath = @$"..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}..{Path.DirectorySeparatorChar}.data{Path.DirectorySeparatorChar}";

        var applicationRoleFileName = @$"{dataPath}ApplicationRole.csv";
        var applicationRoleCsvFilePath = Path.Combine(baseDirectoryPath, applicationRoleFileName);
        await ApplicationRoleImporter.ImportAsync(applicationDbContext, adminUserPass, applicationRoleCsvFilePath);

        var applicationUserRoleFileName = @$"{dataPath}ApplicationUserRole.csv";
        var applicationUserRoleCsvFilePath = Path.Combine(baseDirectoryPath, applicationUserRoleFileName);
        await ApplicationUserRoleImporter.ImportAsync(applicationDbContext, adminUserPass, applicationUserRoleCsvFilePath);

        var applicationUserFileName = @$"{dataPath}ApplicationUser.csv";
        var applicationUserCsvFilePath = Path.Combine(baseDirectoryPath, applicationUserFileName);
        await ApplicationUserImporter.ImportAsync(applicationDbContext, adminUserPass, applicationUserCsvFilePath);

        var castMemberFileName = @$"{dataPath}CastMember.csv";
        var castMemberCsvFilePath = Path.Combine(baseDirectoryPath, castMemberFileName);
        await CastMemberImporter.ImportAsync(applicationDbContext, adminUserPass, castMemberCsvFilePath);

        var castMemberMovieFileName = @$"{dataPath}CastMemberMovie.csv";
        var castMemberMovieCsvFilePath = Path.Combine(baseDirectoryPath, castMemberMovieFileName);
        await CastMemberMovieImporter.ImportAsync(applicationDbContext, adminUserPass, castMemberMovieCsvFilePath);

        var movieFileName = @$"{dataPath}Movie.csv";
        var movieCsvFilePath = Path.Combine(baseDirectoryPath, movieFileName);
        await MovieImporter.ImportAsync(applicationDbContext, adminUserPass, movieCsvFilePath);

        // ImporterFirstCodePlaceholder

        await ApplicationRoleImporter.ImportAsync(applicationDbContext, adminUserPass, applicationRoleCsvFilePath);
        await ApplicationUserRoleImporter.ImportAsync(applicationDbContext, adminUserPass, applicationUserRoleCsvFilePath);
        await ApplicationUserImporter.ImportAsync(applicationDbContext, adminUserPass, applicationUserCsvFilePath);

        await CastMemberImporter.ImportAsync(applicationDbContext, adminUserPass, castMemberCsvFilePath);
        await CastMemberMovieImporter.ImportAsync(applicationDbContext, adminUserPass, castMemberMovieCsvFilePath);
        await MovieImporter.ImportAsync(applicationDbContext, adminUserPass, movieCsvFilePath);
        // ImporterSecondCodePlaceholder
    }
}
