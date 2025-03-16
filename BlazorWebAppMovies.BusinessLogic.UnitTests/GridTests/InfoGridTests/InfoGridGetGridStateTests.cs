using BlazorWebAppMovies.BusinessLogic.Entities;
using BlazorWebAppMovies.BusinessLogic.Grid;

namespace BlazorWebAppMovies.BusinessLogic.UnitTests;

public class InfoGridGetGridStateTests
{
    private List<ApplicationUser> _listApplicationUser;
    private InfoGrid<ApplicationUser> _infoGridApplicationUser;

    [SetUp]
    public void Setup()
    {
        _listApplicationUser =
        [
            new()
            {
                Email = "a@a.a",
                NormalizedEmail = "A@A.A",
                NormalizedUserName = "A",
                PhoneNumber = "",
                UserName = "a",
            },
            new()
            {
                Email = "b@b.b",
                NormalizedEmail = "B@B.B",
                NormalizedUserName = "B",
                PhoneNumber = "",
                UserName = "b",
            },
        ];

        _infoGridApplicationUser = new InfoGrid<ApplicationUser>(_listApplicationUser);
    }

    [Test]
    public void ShouldBeDefaultState()
    {
        var expected = new InfoGridState
        {
            _columns = 0,
            _filters = [],
            _page = 1,
            _rowsPerPage = 10,
            _sorts = [],
            _totalRows = 0,
        };

        var actual = _infoGridApplicationUser._infoGridState;

        Assert.Multiple(() =>
        {
            Assert.That(actual._columns, Is.EqualTo(expected._columns));
            Assert.That(actual._filters, Is.EqualTo(expected._filters));
            Assert.That(actual._page, Is.EqualTo(expected._page));
            Assert.That(actual._rowsPerPage, Is.EqualTo(expected._rowsPerPage));
            Assert.That(actual._sorts, Is.EqualTo(expected._sorts));
            Assert.That(actual._totalRows, Is.EqualTo(expected._totalRows));
        });

    }
}
