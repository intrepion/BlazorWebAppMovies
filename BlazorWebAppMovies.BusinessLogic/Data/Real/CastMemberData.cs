using System.Globalization;
using BlazorWebAppMovies.BusinessLogic.Entities;
using BlazorWebAppMovies.BusinessLogic.Entities.Maps;
using CsvHelper;

namespace BlazorWebAppMovies.BusinessLogic.Data.Real;

public static class CastMemberData
{
    public static async Task SeedAsync(ApplicationDbContext applicationDbContext, ApplicationUser adminUser)
    {
        if (applicationDbContext.CastMembers is null)
        {
            return;
        }

        var fileName = @"..\..\..\..\.data\CastMembers.csv";
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

        applicationDbContext.CastMembers.AddRange(records);
        await applicationDbContext.SaveChangesAsync();
    }
}
