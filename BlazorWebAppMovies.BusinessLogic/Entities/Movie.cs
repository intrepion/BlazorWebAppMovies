using System.ComponentModel.DataAnnotations;

namespace BlazorWebAppMovies.BusinessLogic.Entities;

public class Movie
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public DateTime UpdateDateTime { get; set; }

    public ICollection<CastMemberMovie> MovieCastMembers { get; set; } = [];
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string NormalizedTitle { get; set; } = string.Empty;
    [Required]
    public string Year { get; set; } = string.Empty;
    [Required]
    public string AlphanumericYear { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
