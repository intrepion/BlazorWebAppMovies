using BlazorWebAppMovies.Shared.Grid;
using Bunit;
using NUnit.Framework;

namespace BlazorWebAppMovies.Shared.UnitTests.InfoGridTests;

public class InfoGridTests : BunitContext
{
    [Test]
    public void InfoGridComponentRendersCorrectly()
    {
        // Act
        var cut = Render<InfoGrid>();

        cut.MarkupMatches("<div><p>No information found.</p></div>");
    }
}
