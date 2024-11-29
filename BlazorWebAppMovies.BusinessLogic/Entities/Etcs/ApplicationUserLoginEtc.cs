using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorWebAppMovies.BusinessLogic.Entities.Configuration;

public class ApplicationUserLoginEtc : IEntityTypeConfiguration<ApplicationUserLogin>
{
    public void Configure(EntityTypeBuilder<ApplicationUserLogin> builder)
    {
        builder.HasOne(x => x.ApplicationUserCreatedBy)
            .WithMany(x => x.CreatedApplicationUserLogins)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ApplicationUserUpdatedBy)
            .WithMany(x => x.UpdatedApplicationUserLogins)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
