namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class CastMember
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public ICollection<CastMemberMovie> CastMemberMovies { get; set; } = [];
    public string Name1 { get; set; } = string.Empty;
    public string NormalizedName1 { get; set; } = string.Empty;
    public string Name2 { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
