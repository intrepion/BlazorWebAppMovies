﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorWebAppMovies.BusinessLogic.Entities.Configuration;

public class CastMemberMovieEntityTypeConfiguration : IEntityTypeConfiguration<CastMemberMovie>
{
    public void Configure(EntityTypeBuilder<CastMemberMovie> builder)
    {
        builder.ToTable("CastMemberMovies", x => x.IsTemporal());

        builder.HasOne(x => x.CastMember)
            .WithMany(x => x.CastMemberMovies)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Movie)
            .WithMany(x => x.MovieCastMembers)
            .OnDelete(DeleteBehavior.Restrict);
        // EntityConfigurationCodePlaceholder

        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedCastMemberMovies)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
