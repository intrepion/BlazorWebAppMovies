using Bogus;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace BlazorWebAppMovies.AcceptanceTests.Admin;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class CastMemberAdminPages : PageTest
{
    [Test]
    public async Task MainNavigation()
    {
        var faker = new Faker();
        string aRandomString = faker.Random.String2(10);
        string someRandomString = faker.Random.String2(10);
        await Page.GetByRole(AriaRole.Link, new() { Name = "Cast Members" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Cast Member Home");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create New" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Cast Member Add");

        await Page.GetByLabel("Name 1:").FillAsync("aName1" + aRandomString);
        await Page.GetByLabel("Name 2:").FillAsync("aName2" + aRandomString);
        // CreatePropertyCodePlaceholder

        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Cast Member Add");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Cancel" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Cast Member Home");
        await Page.GetByRole(AriaRole.Link, new() { Name = "aId" + aRandomString }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Edit" }).ClickAsync();

        await Page.GetByLabel("Name 1:").FillAsync("someName1" + someRandomString);
        await Page.GetByLabel("Name 2:").FillAsync("someName2" + someRandomString);
        // ModifyPropertyCodePlaceholder

        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Cast Member View");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Delete" }).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = "Confirm" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "Back to Grid" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Cast Member Home");
    }

    [SetUp]
    public async Task SetUp()
    {
        var baseUrl = Environment.GetEnvironmentVariable("BASE_URL");
        if (string.IsNullOrEmpty(baseUrl))
        {
            baseUrl = "http://localhost:5084";
        }
        await Page.GotoAsync(baseUrl);


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
