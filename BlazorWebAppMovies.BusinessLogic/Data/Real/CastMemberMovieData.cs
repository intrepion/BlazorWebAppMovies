using System.Globalization;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Maps;
using CsvHelper;

namespace ApplicationNamePlaceholder.BusinessLogic.Data.Real;

public static class CastMemberMovieData
{
    public static async Task SeedAsync(ApplicationDbContext applicationDbContext, ApplicationUser adminUser)
    {
        if (applicationDbContext.CastMemberMovies is null)
        {
            return;
        }

        var fileName = @"..\..\..\..\.data\CastMemberMovies.csv";
        var baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
        var csvFilePath = Path.Combine(baseDirectoryPath, fileName);

        if (!File.Exists(csvFilePath))
        {
            return;
        }

        using var reader = new StreamReader(csvFilePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<CastMemberMovieMap>();

        var records = csv.GetRecords<CastMemberMovie>().ToList();

        foreach (var record in records)
        {
            record.ApplicationUserUpdatedBy = adminUser;
        }

        applicationDbContext.CastMemberMovies.AddRange(records);
        await applicationDbContext.SaveChangesAsync();
    }
}
