using BlazorWebAppMovies.Shared.Grid;
using Bunit;
using NUnit.Framework;

namespace BlazorWebAppMovies.Shared.UnitTests.InfoGridTests;

public class InfoGridTests : BunitContext
{
    [Test]
    public void HelloWorldComponentRendersCorrectly()
    {
        // Act
        var cut = Render<Counter>();

        // Assert
        cut.MarkupMatches(@"<h1>Counter</h1>
<p>
  Current count: 0</p>
<button class=""btn btn-primary"" >Click me</button>");
    }
}
