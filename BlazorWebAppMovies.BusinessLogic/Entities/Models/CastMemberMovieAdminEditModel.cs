using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class CastMemberMovieAdminEditModel
{
    public Guid Id { get; set; }

    public CastMember? CastMember { get; set; }
    public Movie? Movie { get; set; }
    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static CastMemberMovieAdminEditModel FromCastMemberMovieAdminDto(CastMemberMovieAdminDto castMemberMovieAdminDto)
    {
        if (castMemberMovieAdminDto == null)
        {
            return new CastMemberMovieAdminEditModel();
        }

        return new CastMemberMovieAdminEditModel
        {
            Id = castMemberMovieAdminDto.Id,

            CastMember = castMemberMovieAdminDto.CastMember,
            Movie = castMemberMovieAdminDto.Movie,
            // DtoToModelPlaceholder
            // Title = castMemberMovieAdminDto.Title,
            // ToDoList = castMemberMovieAdminDto.ToDoList,
        };
    }

    public static CastMemberMovieAdminDto ToCastMemberMovieAdminDto(CastMemberMovieAdminEditModel castMemberMovieAdminEditModel)
    {
        if (castMemberMovieAdminEditModel == null)
        {
            return new CastMemberMovieAdminDto();
        }

        return new CastMemberMovieAdminDto
        {
            Id = castMemberMovieAdminEditModel.Id,

            CastMember = castMemberMovieAdminEditModel.CastMember,
            // ModelToDtoPlaceholder
            // Title = castMemberMovieAdminEditModel.Title,
            // ToDoList = castMemberMovieAdminEditModel.ToDoList,
        };
    }
}
