﻿using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using BlazorWebAppMovies.BusinessLogic.Data;
using BlazorWebAppMovies.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.BusinessLogic.Entities.Importers;

public static class ApplicationUserRoleImporter
{
    public static async Task ImportAsync(
       ApplicationDbContext context,
       string userName, string csvPath
    )
    {
        if (!File.Exists(csvPath))
        {
            Console.WriteLine($"ApplicationUserRole CSV file not found: {csvPath}");
            return;
        }

        if (context.Users is null)
        {
            Console.WriteLine("Database table not found: context.Users");
            return;
        }

        if (context.UserRoles is null)
        {
            Console.WriteLine("Database table not found: context.UserRoles");
            return;
        }

        if (context.Roles is null)
        {
            Console.WriteLine("Database table not found: context.Roles");
            return;
        }

        var normalizedUserName = userName.ToUpperInvariant();
        var applicationUserUpdatedBy = await context.Users.SingleOrDefaultAsync(x => x.NormalizedUserName != null && x.NormalizedUserName.Equals(normalizedUserName));

        if (applicationUserUpdatedBy is null)
        {
            Console.WriteLine("UserName not found: " + userName);
            return;
        }

        using var reader = new StreamReader(csvPath);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = x => x.Header.ToUpper(CultureInfo.InvariantCulture)
        });

        var records = csv.GetRecords<ApplicationUserRoleRecord>();

        var applicationRoleList = await context.Roles.ToListAsync();
        var applicationUserList = await context.Users.ToListAsync();

        foreach (var record in records)
        {
            var applicationRole = applicationRoleList.Single(x =>
                x.NormalizedName == record.ApplicationRole_NormalizedName
            );
            var applicationUser = applicationUserList.Single(x =>
                x.NormalizedUserName == record.ApplicationUser_NormalizedUserName
            );

            if (applicationRole != null && applicationUser != null)
            {
                var applicationUserRole = new ApplicationUserRole
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                    RoleId = applicationRole.Id,
                    UserId = applicationUser.Id
                };

                var dbApplicationUserRole = await context.UserRoles.SingleAsync(
                    x => true
                    && x.RoleId == applicationRole.Id
                    && x.UserId == applicationUser.Id);

                if (dbApplicationUserRole is null)
                {
                    await context.UserRoles.AddAsync(applicationUserRole);
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
