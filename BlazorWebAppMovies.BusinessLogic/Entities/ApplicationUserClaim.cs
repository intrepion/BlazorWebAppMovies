﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BlazorWebAppMovies.BusinessLogic.Entities;

public class ApplicationUserClaim : IdentityUserClaim<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public DateTime UpdateDateTime { get; set; }

    // ActualPropertyPlaceholder
}
