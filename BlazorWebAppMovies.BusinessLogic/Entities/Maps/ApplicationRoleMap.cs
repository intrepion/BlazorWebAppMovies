using CsvHelper.Configuration;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Maps;

public sealed class ApplicationRoleMap : ClassMap<ApplicationRole>
{
    public ApplicationRoleMap()
    {
        Map(m => m.ApplicationUserUpdatedBy).Ignore();
        Map(m => m.Id).Ignore();
        Map(m => m.Name).Name("Name");
        Map(m => m.NormalizedName)
            .Name("Name")
            .Convert(args => args.Row.GetField("Name")?.ToUpperInvariant());
    }
}
