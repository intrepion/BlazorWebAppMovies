﻿using BlazorWebAppMovies.BusinessLogic.Entities;
using BlazorWebAppMovies.BusinessLogic.Entities.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.BusinessLogic.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>(options)
{
    public DbSet<CastMember> CastMembers { get; set; }
    public DbSet<CastMemberMovie> CastMemberMovies { get; set; }
    public DbSet<Movie> Movies { get; set; }
    // DbSetCodePlaceholder

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        new ApplicationRoleClaimEntityTypeConfiguration().Configure(builder.Entity<ApplicationRoleClaim>());
        new ApplicationRoleEntityTypeConfiguration().Configure(builder.Entity<ApplicationRole>());
        new ApplicationUserEntityTypeConfiguration().Configure(builder.Entity<ApplicationUser>());
        new ApplicationUserClaimEntityTypeConfiguration().Configure(builder.Entity<ApplicationUserClaim>());
        new ApplicationUserLoginEntityTypeConfiguration().Configure(builder.Entity<ApplicationUserLogin>());
        new ApplicationUserRoleEntityTypeConfiguration().Configure(builder.Entity<ApplicationUserRole>());
        new ApplicationUserTokenEntityTypeConfiguration().Configure(builder.Entity<ApplicationUserToken>());

        new CastMemberEntityTypeConfiguration().Configure(builder.Entity<CastMember>());
        new CastMemberMovieEntityTypeConfiguration().Configure(builder.Entity<CastMemberMovie>());
        new MovieEntityTypeConfiguration().Configure(builder.Entity<Movie>());
        // EntityTypeCfgCodePlaceholder
    }
}
