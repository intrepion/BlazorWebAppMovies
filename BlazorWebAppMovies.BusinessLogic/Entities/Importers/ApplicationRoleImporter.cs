using System.Globalization;
using BlazorWebAppMovies.BusinessLogic.Data;
using BlazorWebAppMovies.BusinessLogic.Entities.Records;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.BusinessLogic.Entities.Importers;

public class ApplicationRoleImporter(IDbContextFactory<ApplicationDbContext> contextFactory)
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;

    public async Task ImportAsync(string userName, string csvPath)
    {
        if (!File.Exists(csvPath))
        {
            Console.WriteLine("File not found: " + csvPath);
            return;
        }

        using var context = await _contextFactory.CreateDbContextAsync();

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
            PrepareHeaderForMatch = args => args.Header.ToUpper(CultureInfo.InvariantCulture)

        });

        var records = csv.GetRecords<ApplicationRoleRecord>();

        foreach (var record in records)
        {
            var applicationRole = new ApplicationRole
            {
                ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                Id = Guid.NewGuid(),
                Name = record.Name,
                NormalizedName = record.Name.ToUpper(CultureInfo.InvariantCulture),
            };

            var existingApplicationRole = await context.Roles.FirstOrDefaultAsync(m => m.NormalizedName == applicationRole.NormalizedName);
            if (existingApplicationRole != null)
            {
                // Update existing Application Role
                existingApplicationRole.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                // Update other properties as needed
            }
            else
            {
                // Add new Application Role
                await context.Roles.AddAsync(applicationRole);
            }
        }

        await context.SaveChangesAsync();
    }
}
