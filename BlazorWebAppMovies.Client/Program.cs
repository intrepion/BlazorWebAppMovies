﻿using BlazorWebAppMovies.BusinessLogic.Services;
using BlazorWebAppMovies.BusinessLogic.Services.Client;
using BlazorWebAppMovies.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});
builder.Services.AddScoped<IApplicationRoleAdminService, ApplicationRoleClientAdminService>();
builder.Services.AddScoped<IApplicationUserAdminService, ApplicationUserClientAdminService>();

builder.Services.AddScoped<ICastMemberAdminService, CastMemberClientAdminService>();
builder.Services.AddScoped<ICastMemberMovieAdminService, CastMemberMovieClientAdminService>();
builder.Services.AddScoped<IMovieAdminService, MovieClientAdminService>();
// RegisterClientServiceCodePlaceholder

await builder.Build().RunAsync();
