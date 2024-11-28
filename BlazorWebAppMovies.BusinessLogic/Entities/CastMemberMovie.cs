﻿using System.ComponentModel.DataAnnotations;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class CastMemberMovie
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime UpdateDateTime { get; set; }

    public CastMember? CastMember { get; set; }
    public Movie? Movie { get; set; }
    // ActualPropertyPlaceholder
}
