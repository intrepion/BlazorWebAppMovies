using BlazorWebAppMovies.BusinessLogic.Data;
using BlazorWebAppMovies.BusinessLogic.Entities;
using BlazorWebAppMovies.BusinessLogic.Grid;
using BlazorWebAppMovies.BusinessLogic.Grid.Admin.ApplicationRoleGrid;
using BlazorWebAppMovies.BusinessLogic.Grid.Admin.ApplicationUserGrid;

using BlazorWebAppMovies.BusinessLogic.Grid.Admin.CastMemberGrid;
using BlazorWebAppMovies.BusinessLogic.Grid.Admin.CastMemberMovieGrid;
using BlazorWebAppMovies.BusinessLogic.Grid.Admin.MovieGrid;
// GridNamespaceCodePlaceholder

using BlazorWebAppMovies.Components;
using BlazorWebAppMovies.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

if (builder.Environment.EnvironmentName == "Test")
{
    builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
        options
            .EnableSensitiveDataLogging()
            .UseSqlite(connectionString)
    );
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
}

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseUri").Value!),
});

builder.Services.AddScoped<IPageHelper, PageHelper>();
builder.Services.AddScoped<EditSuccess>();

builder.Services.AddScoped<IApplicationRoleFilters, ApplicationRoleGridControls>();
builder.Services.AddScoped<ApplicationRoleGridQueryAdapter>();

builder.Services.AddScoped<IApplicationUserFilters, ApplicationUserGridControls>();
builder.Services.AddScoped<ApplicationUserGridQueryAdapter>();

builder.Services.AddScoped<ICastMemberFilters, CastMemberGridControls>();
builder.Services.AddScoped<CastMemberGridQueryAdapter>();

builder.Services.AddScoped<ICastMemberMovieFilters, CastMemberMovieGridControls>();
builder.Services.AddScoped<CastMemberMovieGridQueryAdapter>();

builder.Services.AddScoped<IMovieFilters, MovieGridControls>();
builder.Services.AddScoped<MovieGridQueryAdapter>();

// RegisterServerServiceCodePlaceholder

var app = builder.Build();

if (app.Environment.EnvironmentName == "Test")
{
    app.UseWebAssemblyDebugging();
    await using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();
    var options = scope.ServiceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>();
    await DatabaseUtility.EnsureDbCreatedAndSeedAsync(scope.ServiceProvider);
}

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorWebAppMovies.Client._Imports).Assembly);

app.MapAdditionalIdentityEndpoints();

app.Run();
