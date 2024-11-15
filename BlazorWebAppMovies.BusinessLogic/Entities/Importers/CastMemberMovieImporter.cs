using System.Globalization;
using BlazorWebAppMovies.BusinessLogic.Data;
using BlazorWebAppMovies.BusinessLogic.Entities.Records;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.BusinessLogic.Entities.Importers;

public class CastMemberMovieImporter
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public CastMemberMovieImporter(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task ImportAsync(string userName, string csvPath)
    {
        if (!File.Exists(csvPath))
        {
            Console.WriteLine($"CastMemberMovie CSV file not found: {csvPath}");
            return;
        }

        using var context = await _contextFactory.CreateDbContextAsync();

        if (context.CastMembers is null)
        {
            Console.WriteLine("Database table not found: context.CastMembers");
            return;
        }

        if (context.CastMemberMovies is null)
        {
            Console.WriteLine("Database table not found: context.CastMembers");
            return;
        }

        if (context.Movies is null)
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

        var records = csv.GetRecords<CastMemberMovieRecord>();
        var movies = await context.Movies.ToListAsync();
        var castMembers = await context.CastMembers.ToListAsync();

        foreach (var record in records)
        {
            var castMember = castMembers.FirstOrDefault(c =>
                c.NormalizedName1 == record.CastMemberNormalizedName1 && c.NormalizedName2 == record.CastMemberNormalizedName2);
            var movie = movies.FirstOrDefault(m =>
                m.NormalizedTitle == record.MovieNormalizedTitle && m.Year == record.MovieYear);

            if (castMember != null && movie != null)
            {
                var castMemberMovie = new CastMemberMovie
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                    CastMember = castMember,
                    Movie = movie
                };

                var existingCastMemberMovie = await context.CastMemberMovies.FirstOrDefaultAsync(x =>
                    x.CastMember != null &&
                    x.CastMember.NormalizedName1 == castMemberMovie.CastMember.NormalizedName1 &&
                    x.CastMember.NormalizedName2 == castMemberMovie.CastMember.NormalizedName2 &&
                    x.Movie != null &&
                    x.Movie.NormalizedTitle == castMemberMovie.Movie.NormalizedTitle &&
                    x.Movie.Year == castMemberMovie.Movie.Year);

                if (existingCastMemberMovie is not null)
                {
                    // Update existing movie
                    existingCastMemberMovie.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                    // Update other properties as needed
                }
                else
                {
                    // Add new cast member movie relationship
                    await context.CastMemberMovies.AddAsync(castMemberMovie);
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
