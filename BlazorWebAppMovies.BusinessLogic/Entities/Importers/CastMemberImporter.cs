using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Importers;

public static class CastMemberImporter
{
    public static async Task ImportAsync(
       ApplicationDbContext context,
       string userName, string csvPath
    )
    {
        if (!File.Exists(csvPath))
        {
            Console.WriteLine("File not found: " + csvPath);
            return;
        }

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
            PrepareHeaderForMatch = x => x.Header.ToUpper(CultureInfo.InvariantCulture),
            Delimiter = "|",
        });

        var records = csv.GetRecords<CastMemberRecord>();

        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            // ManyToOneCodePlaceholder

            if (true
                // NullCheckCodePlaceholder
            )
            {
                var castMember = new CastMember
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,

                    Name1 = record.Name1,
                    // NewEntityCodePlaceholder
                };

                var dbCastMember = await context.CastMembers.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedName1 == castMember.NormalizedName1
                    && x.NormalizedName2 == castMember.NormalizedName2
                    // CompositeKeyCodePlaceholder
                );

                if (dbCastMember is null)
                {
                    await context.CastMembers.AddAsync(castMember);
                }
                else
                {
                    dbCastMember.ApplicationUserUpdatedBy = applicationUserUpdatedBy;

                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
