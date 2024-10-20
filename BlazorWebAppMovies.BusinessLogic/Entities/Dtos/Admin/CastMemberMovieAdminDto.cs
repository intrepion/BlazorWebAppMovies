﻿namespace BlazorWebAppMovies.BusinessLogic.Entities.Dtos.Admin;

public class CastMemberMovieAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public CastMember? CastMember { get; set; }
    public Movie? Movie { get; set; }
    // DtoPropertyPlaceholder

    public static CastMemberMovieAdminDto FromCastMemberMovie(CastMemberMovie? castMemberMovie)
    {
        if (castMemberMovie == null)
        {
            return new CastMemberMovieAdminDto();
        }

        return new CastMemberMovieAdminDto
        {
            Id = castMemberMovie.Id,

            CastMember = castMemberMovie.CastMember,
            Movie = castMemberMovie.Movie,
            // EntityToDtoPlaceholder
        };
    }

    public static CastMemberMovie ToCastMemberMovie(ApplicationUser? applicationUser, CastMemberMovieAdminDto? castMemberMovieAdminDto)
    {
        return new CastMemberMovie
        {
            ApplicationUserUpdatedBy = applicationUser ?? new ApplicationUser(),
            Id = castMemberMovieAdminDto?.Id ?? new Guid(),

            CastMember = castMemberMovieAdminDto.CastMember,
            Movie = castMemberMovieAdminDto.Movie,
            // DtoToEntityPropertyPlaceholder
        };
    }
}
