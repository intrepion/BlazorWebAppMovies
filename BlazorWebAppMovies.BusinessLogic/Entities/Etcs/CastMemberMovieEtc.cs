using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Configuration;

public class CastMemberMovieEtc : IEntityTypeConfiguration<CastMemberMovie>
{
    public void Configure(EntityTypeBuilder<CastMemberMovie> builder)
    {
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedCastMemberMovies)
            .OnDelete(DeleteBehavior.Restrict);

        // EntityConfigurationCodePlaceholder
    }
}
