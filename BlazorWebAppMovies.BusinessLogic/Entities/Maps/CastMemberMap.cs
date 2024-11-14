using CsvHelper.Configuration;

namespace BlazorWebAppMovies.BusinessLogic.Entities.Maps;

public sealed class CastMemberMap : ClassMap<CastMember>
{
    public CastMemberMap()
    {
        Map(m => m.ApplicationUserUpdatedBy).Ignore();
        Map(m => m.Id).Ignore();

        Map(m => m.Name1).Name("Name1");
        Map(m => m.NormalizedName1).Name("Name1").Convert(args => args.Row.GetField("Name1")?.ToUpperInvariant());
        Map(m => m.Name2).Name("Name2");
        Map(m => m.NormalizedName2).Name("Name2").Convert(args => args.Row.GetField("Name2")?.ToUpperInvariant());
        // MappingCodePlaceholder
        // Map(m => m.Name).Name("Name");
        // Map(m => m.NormalizedName)
        //     .Name("Name")
        //     .Convert(args => args.Row.GetField("Name")?.ToUpperInvariant());
    }
}
