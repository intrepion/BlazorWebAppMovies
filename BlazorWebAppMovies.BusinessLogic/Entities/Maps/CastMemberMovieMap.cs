using CsvHelper.Configuration;

namespace BlazorWebAppMovies.BusinessLogic.Entities.Maps;

public sealed class CastMemberMovieMap : ClassMap<CastMemberMovie>
{
    public CastMemberMovieMap()
    {
        Map(m => m.ApplicationUserUpdatedBy).Ignore();
        Map(m => m.Id).Ignore();

        // MappingCodePlaceholder
        // Map(m => m.Name).Name("Name");
        // Map(m => m.NormalizedName)
        //     .Name("Name")
        //     .Convert(args => args.Row.GetField("Name")?.ToUpperInvariant());
    }
}
