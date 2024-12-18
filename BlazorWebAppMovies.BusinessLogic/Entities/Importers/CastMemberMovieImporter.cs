﻿using System.Globalization;
using BlazorWebAppMovies.BusinessLogic.Data;
using BlazorWebAppMovies.BusinessLogic.Entities.Records;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.BusinessLogic.Entities.Importers;

public static class CastMemberMovieImporter
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

        if (context.CastMemberMovies is null)
        {
            Console.WriteLine("Database table not found: context.CastMemberMovies");
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

        var records = csv.GetRecords<CastMemberMovieRecord>();

        var castMemberList = await context.CastMembers.ToListAsync();
        var movieList = await context.Movies.ToListAsync();
        // EntityListCodePlaceholder

        foreach (var record in records)
        {
            var castMember = castMemberList.FirstOrDefault(x =>
                true
                && x.NormalizedName1.Equals(record.CastMember_NormalizedName1)
                && x.NormalizedName2.Equals(record.CastMember_NormalizedName2)
            );

            var movie = movieList.FirstOrDefault(x =>
                true
                && x.NormalizedTitle.Equals(record.Movie_NormalizedTitle)
                && x.Year.Equals(record.Movie_Year)
            );

            // ManyToOneCodePlaceholder

            if (true
                && castMember is not null
                && movie is not null
            // NullCheckCodePlaceholder
            )
            {
                var castMemberMovie = new CastMemberMovie
                {
                    ApplicationUserUpdatedBy = applicationUserUpdatedBy,
                    UpdateDateTime = DateTime.UtcNow,

                    CastMember = castMember,
                    Movie = movie,
                    // NewEntityCodePlaceholder
                };

                var dbCastMemberMovie = await context.CastMemberMovies.SingleOrDefaultAsync(
                    x => true
                    && x.CastMember.Equals(castMember)
                    && x.Movie.Equals(movie)
                    // CompositeKeyCodePlaceholder
                );

                if (dbCastMemberMovie is null)
                {
                    await context.CastMemberMovies.AddAsync(castMemberMovie);
                }
                else
                {
                    dbCastMemberMovie.ApplicationUserUpdatedBy = applicationUserUpdatedBy;
                    dbCastMemberMovie.UpdateDateTime = DateTime.UtcNow;

                    dbCastMemberMovie.CastMember = castMember;
                    dbCastMemberMovie.Movie = movie;
                    // ExistingEntityCodePlaceholder
                }
            }
        }

        await context.SaveChangesAsync();
    }
}
