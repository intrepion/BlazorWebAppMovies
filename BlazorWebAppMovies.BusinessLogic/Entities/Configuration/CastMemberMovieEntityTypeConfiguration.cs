using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Configuration;

public class CastMemberMovieEntityTypeConfiguration : IEntityTypeConfiguration<CastMemberMovie>
{
    public void Configure(EntityTypeBuilder<CastMemberMovie> builder)
    {
        builder.ToTable("CastMemberMovies", x => x.IsTemporal());

        // EntityConfigurationCodePlaceholder

        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedCastMemberMovies)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
