﻿using BlazorWebAppMovies.BusinessLogic.Data.Real;
using BlazorWebAppMovies.BusinessLogic.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlazorWebAppMovies.BusinessLogic.Data;

public static class DatabaseUtility
{
    public static async Task EnsureDbCreatedAndSeedAsync(DbContextOptions<ApplicationDbContext> options, IServiceProvider serviceProvider)
    {
        var factory = new LoggerFactory();
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>(options)
            .UseLoggerFactory(factory);

        using var applicationDbContext = new ApplicationDbContext(builder.Options);

        if (await applicationDbContext.Database.EnsureCreatedAsync())
        {
            var adminName = "Admin";
            var adminUserPass = adminName + "1@BlazorWebAppMovies.com";
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

            await ApplicationRoleData.SeedAsync(applicationDbContext, adminUser);

            await CastMemberData.SeedAsync(applicationDbContext, adminUser);
            await CastMemberMovieData.SeedAsync(applicationDbContext, adminUser);
            await MovieData.SeedAsync(applicationDbContext, adminUser);
            // ReadDataCodePlaceholder

            await FakeData.SeedAsync(applicationDbContext, adminUser);
        }
    }
}
