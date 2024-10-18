using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace ApplicationNamePlaceholder.AcceptanceTests.Admin;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class CastMemberAdminPages : PageTest
{
    [Test]
    public async Task MainNavigation()
    {
        await Expect(Page).ToHaveTitleAsync("Home");
        await Page.GetByTestId("castMemberNavLink").ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Cast Member List");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Cast Member Creation");

        await Page.GetByTestId("castMemberAdminEditName1").FillAsync("a castMember");
        // CreatePropertyCodePlaceholder

        await Page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Cast Member Modification");

        // ModifyPropertyCodePlaceholder

        await Page.GetByRole(AriaRole.Button, new() { Name = "Modify" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Cast Member Modification");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Remove" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Cast Member List");
    }

    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync("http://localhost:5077");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();
        await Expect(Page).ToHaveTitleAsync("Log in");
        await Page.GetByTestId("loginEmail").FillAsync("Admin1@ApplicationNamePlaceholder.com");
        await Page.GetByTestId("loginPassword").FillAsync("Admin1@ApplicationNamePlaceholder.com");
        await Page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        await Page.GetByRole(AriaRole.Button, new() { Name = "Logout" }).ClickAsync();
    }
}
