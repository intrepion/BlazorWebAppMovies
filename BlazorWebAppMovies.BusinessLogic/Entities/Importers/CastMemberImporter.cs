using System.Globalization;
using BlazorWebAppMovies.BusinessLogic.Data;
using BlazorWebAppMovies.BusinessLogic.Entities.Records;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.BusinessLogic.Entities.Importers;

public class CastMemberImporter(IDbContextFactory<ApplicationDbContext> contextFactory)
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

        if (context.CastMembers is null)
        {
            Console.WriteLine("Database table not found: context.CastMembers");
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

        var records = csv.GetRecords<CastMemberRecord>();

        foreach (var record in records)
        {
            var castMember = new CastMember
            {
                ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                Id = Guid.NewGuid(),
                Name1 = record.Name1,
                Name2 = record.Name2,
                NormalizedName1 = record.Name1.ToUpper(CultureInfo.InvariantCulture),
                NormalizedName2 = record.Name2.ToUpper(CultureInfo.InvariantCulture),
            };

            var existingCastMember = await context.CastMembers.FirstOrDefaultAsync(x => x.NormalizedName1 == castMember.NormalizedName1 && x.NormalizedName2 == castMember.NormalizedName2);
            if (existingCastMember is not null)
            {
                // Update existing castMember
                existingCastMember.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                existingCastMember.Name1 = castMember.Name1;
                existingCastMember.Name2 = castMember.Name2;
                existingCastMember.NormalizedName1 = record.Name1.ToUpper(CultureInfo.InvariantCulture);
                existingCastMember.NormalizedName2 = record.Name2.ToUpper(CultureInfo.InvariantCulture);
                // Update other properties as needed
            }
            else
            {
                // Add new castMember
                await context.CastMembers.AddAsync(castMember);
            }
        }

        await context.SaveChangesAsync();
    }
}
