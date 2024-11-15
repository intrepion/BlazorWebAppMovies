using BlazorWebAppMovies.BusinessLogic.Entities;
using BlazorWebAppMovies.BusinessLogic.Entities.Importers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlazorWebAppMovies.BusinessLogic.Data;

public static class DatabaseUtility
{
    public static async Task EnsureDbCreatedAndSeedAsync(
        DbContextOptions<ApplicationDbContext> options,
        IServiceProvider serviceProvider
    )
    {
        Console.WriteLine("EnsureDbCreatedAndSeedAsync");
        var factory = new LoggerFactory();
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>(options)
            .UseLoggerFactory(factory);

        using var applicationDbContext = new ApplicationDbContext(builder.Options);

        var isNewDatabase = await applicationDbContext.Database.EnsureCreatedAsync();

        var adminName = "Admin";
        var adminUserPass = adminName + "1@BlazorWebAppMovies.com";
        var adminNormalizedUserName = adminUserPass.ToUpperInvariant();

        Console.WriteLine("Before check for new database");
        if (isNewDatabase)
        {
            Console.WriteLine("database is new");
            var adminUser = (await applicationDbContext.Users.AddAsync(new ApplicationUser
            {
                Email = adminUserPass,
                EmailConfirmed = true,
                NormalizedEmail = adminUserPass.ToUpperInvariant(),
                NormalizedUserName = adminUserPass.ToUpperInvariant(),
                UserName = adminUserPass,
            })).Entity;

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
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

        var applicationRoleFileName = @"..\..\..\..\.data\ApplicationRole.csv";
        var applicationRoleCsvFilePath = Path.Combine(baseDirectoryPath, applicationRoleFileName);
        await ApplicationRoleImporter.ImportAsync(applicationDbContext, adminUserPass, applicationRoleCsvFilePath);

        var castMemberFileName = @"..\..\..\..\.data\CastMember.csv";
        var castMemberCsvFilePath = Path.Combine(baseDirectoryPath, castMemberFileName);
        await CastMemberImporter.ImportAsync(applicationDbContext, adminUserPass, castMemberCsvFilePath);

        var castMemberMovieFileName = @"..\..\..\..\.data\CastMemberMovie.csv";
        var castMemberMovieCsvFilePath = Path.Combine(baseDirectoryPath, castMemberMovieFileName);
        await CastMemberMovieImporter.ImportAsync(applicationDbContext, adminUserPass, castMemberMovieCsvFilePath);

        var movieFileName = @"..\..\..\..\.data\Movie.csv";
        var movieCsvFilePath = Path.Combine(baseDirectoryPath, movieFileName);
        await MovieImporter.ImportAsync(applicationDbContext, adminUserPass, movieCsvFilePath);

        await ApplicationRoleImporter.ImportAsync(applicationDbContext, adminUserPass, applicationRoleCsvFilePath);
        await CastMemberImporter.ImportAsync(applicationDbContext, adminUserPass, castMemberCsvFilePath);
        await CastMemberMovieImporter.ImportAsync(applicationDbContext, adminUserPass, castMemberMovieCsvFilePath);
        await MovieImporter.ImportAsync(applicationDbContext, adminUserPass, movieCsvFilePath);

        // ImporterCodePlaceholder
    }
}
