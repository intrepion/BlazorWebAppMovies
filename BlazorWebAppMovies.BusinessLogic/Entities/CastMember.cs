using System.ComponentModel.DataAnnotations;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class CastMember
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public ICollection<CastMemberMovie> CastMemberMovies { get; set; } = [];
    [Required]
    public string Name1 { get; set; } = string.Empty;
    [Required]
    // ActualPropertyPlaceholder
}
