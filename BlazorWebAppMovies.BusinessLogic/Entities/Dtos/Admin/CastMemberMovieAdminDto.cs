namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos.Admin;

public class CastMemberMovieAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

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

            // EntityToDtoPlaceholder
        };
    }

    public static CastMemberMovie ToCastMemberMovie(ApplicationUser? applicationUser, CastMemberMovieAdminDto? castMemberMovieAdminDto)
    {
        return new CastMemberMovie
        {
            ApplicationUserUpdatedBy = applicationUser ?? new ApplicationUser(),
            Id = castMemberMovieAdminDto?.Id ?? new Guid(),

            // DtoToEntityPropertyPlaceholder
        };
    }
}
