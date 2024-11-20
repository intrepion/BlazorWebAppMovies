using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using ApplicationNamePlaceholder.BusinessLogic.Data;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Records;
using Microsoft.EntityFrameworkCore;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Importers;

public static class MovieImporter
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

        if (context.Movies is null)
        {
            Console.WriteLine("Database table not found: context.Movies");
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

        var records = csv.GetRecords<MovieRecord>();

        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            // ManyToOneCodePlaceholder

            if (true
                // NullCheckCodePlaceholder
            )
            {
                var movie = new Movie
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,

                    Title = record.Title,
                    NormalizedTitle = record.Title.ToUpper(CultureInfo.InvariantCulture),
                    Year = record.Year,
                    // NewEntityCodePlaceholder
                };

                var dbMovie = await context.Movies.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedTitle == movie.NormalizedTitle
                    && x.Year == movie.Year
                    // CompositeKeyCodePlaceholder
                );

                if (dbMovie is null)
                {
                    await context.Movies.AddAsync(movie);
                }
                else
                {
                    dbMovie.ApplicationUserUpdatedBy = applicationUserUpdatedBy;

                    dbMovie.Title = record.Title;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
