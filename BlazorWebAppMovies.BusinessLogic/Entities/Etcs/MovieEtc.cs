using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Configuration;

public class MovieEtc : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movies", x => x.IsTemporal());

        // EntityConfigurationCodePlaceholder

        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedMovies)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
