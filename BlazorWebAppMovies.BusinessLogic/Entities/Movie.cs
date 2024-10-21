namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class Movie
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public ICollection<CastMemberMovie> MovieCastMembers { get; set; } = [];
    public string Title { get; set; } = string.Empty;
    public string NormalizedTitle { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
