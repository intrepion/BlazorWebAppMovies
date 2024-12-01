﻿// <auto-generated />
using System;
using BlazorWebAppMovies.BusinessLogic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorWebAppMovies.BusinessLogic.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.CastMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.ToTable("CastMembers");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.CastMemberMovie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CastMemberId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.HasIndex("CastMemberId");

                    b.HasIndex("MovieId");

                    b.ToTable("CastMemberMovies");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserUpdatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NormalizedTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserUpdatedById");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationRole", b =>
                {
                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationRoles")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationRoleClaim", b =>
                {
                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationRoleClaims")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", b =>
                {
                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUsers")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUserClaim", b =>
                {
                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserClaims")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUserLogin", b =>
                {
                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserLogins")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUserRole", b =>
                {
                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserRoles")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationRole", "ApplicationRole")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicationUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationRole");

                    b.Navigation("ApplicationUser");

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUserToken", b =>
                {
                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedApplicationUserTokens")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.CastMember", b =>
                {
                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedCastMembers")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.CastMemberMovie", b =>
                {
                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedCastMemberMovies")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.CastMember", "CastMember")
                        .WithMany("CastMemberMovies")
                        .HasForeignKey("CastMemberId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.Movie", "Movie")
                        .WithMany("MovieCastMembers")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUserUpdatedBy");

                    b.Navigation("CastMember");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.Movie", b =>
                {
                    b.HasOne("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", "ApplicationUserUpdatedBy")
                        .WithMany("UpdatedMovies")
                        .HasForeignKey("ApplicationUserUpdatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ApplicationUserUpdatedBy");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationRole", b =>
                {
                    b.Navigation("ApplicationUserRoles");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.ApplicationUser", b =>
                {
                    b.Navigation("ApplicationUserRoles");

                    b.Navigation("UpdatedApplicationRoleClaims");

                    b.Navigation("UpdatedApplicationRoles");

                    b.Navigation("UpdatedApplicationUserClaims");

                    b.Navigation("UpdatedApplicationUserLogins");

                    b.Navigation("UpdatedApplicationUserRoles");

                    b.Navigation("UpdatedApplicationUserTokens");

                    b.Navigation("UpdatedApplicationUsers");

                    b.Navigation("UpdatedCastMemberMovies");

                    b.Navigation("UpdatedCastMembers");

                    b.Navigation("UpdatedMovies");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.CastMember", b =>
                {
                    b.Navigation("CastMemberMovies");
                });

            modelBuilder.Entity("BlazorWebAppMovies.BusinessLogic.Entities.Movie", b =>
                {
                    b.Navigation("MovieCastMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
