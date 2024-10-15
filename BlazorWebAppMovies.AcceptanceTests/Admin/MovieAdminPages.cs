using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace BlazorWebAppMovies.AcceptanceTests.Admin;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class MovieAdminPages : PageTest
{
    [Test]
    public async Task MainNavigation()
    {
        await Expect(Page).ToHaveTitleAsync("Home");
        await Page.GetByTestId("movieNavLink").ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Movie List");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Movie Creation");

        await Page.GetByTestId("movieAdminEditTitle").FillAsync("a movie");
        // CreatePropertyCodePlaceholder
        // await Page.GetByTestId("movieAdminEditName").FillAsync("a movie");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Movie Modification");

        await Page.GetByTestId("movieAdminEditTitle").FillAsync("some movie");
        // ModifyPropertyCodePlaceholder
        // await Page.GetByTestId("movieAdminEditName").FillAsync("some movie");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Modify" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Movie Modification");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Remove" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Movie List");
    }

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync("http://localhost:5277");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Log in");
        await Page.GetByTestId("loginEmail").FillAsync("Admin1@BlazorWebAppMovies.com");
        await Page.GetByTestId("loginPassword").FillAsync("Admin1@BlazorWebAppMovies.com");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        await Page.GetByRole(AriaRole.Button, new() { Name = "Logout" }).ClickAsync();
    }
}
