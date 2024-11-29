using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorWebAppMovies.BusinessLogic.Entities.Configuration;

public class MovieEtc : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasOne(x => x.ApplicationUserCreatedBy)
            .WithMany(x => x.CreatedMovies)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedMovies)
            .OnDelete(DeleteBehavior.Restrict);

        // EntityConfigurationCodePlaceholder
    }
}
