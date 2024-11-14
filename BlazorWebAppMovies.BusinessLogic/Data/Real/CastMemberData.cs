using System.Globalization;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Maps;
using CsvHelper;

namespace ApplicationNamePlaceholder.BusinessLogic.Data.Real;

public static class CastMemberData
{
    public static async Task SeedAsync(ApplicationDbContext applicationDbContext, ApplicationUser adminUser)
    {
        if (applicationDbContext.TableNamePlaceholder is null)
        {
            return;
        }

        var fileName = @"..\..\..\..\.data\TableNamePlaceholder.csv";
        var baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        var csvFilePath = Path.Combine(baseDirectoryPath, fileName);

        if (!File.Exists(csvFilePath))
        {
            return;
        }

        using var reader = new StreamReader(csvFilePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<CastMemberMap>();

        var records = csv.GetRecords<CastMember>().ToList();

        foreach (var record in records)
        {
            record.ApplicationUserUpdatedBy = adminUser;
        }

        applicationDbContext.TableNamePlaceholder.AddRange(records);
        await applicationDbContext.SaveChangesAsync();
    }
}
