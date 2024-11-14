using CsvHelper.Configuration;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Maps;

public sealed class MovieMap : ClassMap<Movie>
{
    public MovieMap()
    {
        Map(m => m.ApplicationUserUpdatedBy).Ignore();
        Map(m => m.Id).Ignore();

        Map(m => m.Title).Name("Title");
        Map(m => m.NormalizedTitle).Name("Title").Convert(args => args.Row.GetField("Title")?.ToUpperInvariant());
        Map(m => m.Year).Name("Year");
        // MappingCodePlaceholder
        // Map(m => m.Name).Name("Name");
        // Map(m => m.NormalizedName)
        //     .Name("Name")
        //     .Convert(args => args.Row.GetField("Name")?.ToUpperInvariant());
    }
}
