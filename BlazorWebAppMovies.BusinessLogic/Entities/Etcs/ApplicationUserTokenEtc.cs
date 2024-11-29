using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorWebAppMovies.BusinessLogic.Entities.Configuration;

public class ApplicationUserTokenEtc : IEntityTypeConfiguration<ApplicationUserToken>
{
    public void Configure(EntityTypeBuilder<ApplicationUserToken> builder)
    {
        builder.HasOne(x => x.ApplicationUserCreatedBy)
            .WithMany(x => x.CreatedApplicationUserTokens)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedApplicationUserTokens)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
