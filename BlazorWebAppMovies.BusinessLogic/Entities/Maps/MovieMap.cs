﻿using CsvHelper.Configuration;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Maps;

public sealed class MovieMap : ClassMap<Movie>
{
    public MovieMap()
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
