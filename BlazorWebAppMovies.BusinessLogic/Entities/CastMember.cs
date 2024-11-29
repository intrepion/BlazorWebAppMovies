using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppMovies.BusinessLogic.Entities;

public class CastMember
{
    public ApplicationUser? ApplicationUserCreatedBy { get; set; }
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }

    public ICollection<CastMemberMovie> CastMemberMovies { get; set; } = [];
    [Required]
    public string Name1 { get; set; } = string.Empty;
    [Required]
    public string NormalizedName1 { get; set; } = string.Empty;
    [Required]
    public string Name2 { get; set; } = string.Empty;
    [Required]
    public string NormalizedName2 { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
