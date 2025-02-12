using System.Globalization;
using BlazorWebAppMovies.BusinessLogic.Data;
using BlazorWebAppMovies.BusinessLogic.Entities.Records;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.BusinessLogic.Entities.Importers;

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
                    UpdateDateTime = DateTime.UtcNow,

                    Title = record.Title,
                    NormalizedTitle = record.Title.ToUpper(CultureInfo.InvariantCulture),
                    Year = record.Year,
                    // NewEntityCodePlaceholder
                };

                var dbMovie = await context.Movies.SingleOrDefaultAsync(
                    x => true
                    && x.NormalizedTitle.Equals(movie.NormalizedTitle)
                    && x.Year.Equals(movie.Year)
                    // CompositeKeyCodePlaceholder
                );

                if (dbMovie is null)
                {
                    await context.Movies.AddAsync(movie);
                }
                else
                {
                    dbMovie.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                    dbMovie.UpdateDateTime = DateTime.UtcNow;

                    dbMovie.Title = record.Title;
                    dbMovie.Year = record.Year;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
