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
            PrepareHeaderForMatch = args => args.Header.ToUpper(CultureInfo.InvariantCulture)

        });

        var records = csv.GetRecords<MovieRecord>();

        foreach (var record in records)
        {
            var movie = new Movie
            {
                ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                Id = Guid.NewGuid(),
                Title = record.Title,
                NormalizedTitle = record.Title.ToUpper(CultureInfo.InvariantCulture),
                Year = record.Year
            };

            var existingMovie = await context.Movies.FirstOrDefaultAsync(x => x.NormalizedTitle == movie.NormalizedTitle && x.Year == movie.Year);
            if (existingMovie is not null)
            {
                // Update existing movie
                existingMovie.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                // Update other properties as needed
            }
            else
            {
                // Add new movie
                await context.Movies.AddAsync(movie);
            }
        }

        await context.SaveChangesAsync();
    }
}
