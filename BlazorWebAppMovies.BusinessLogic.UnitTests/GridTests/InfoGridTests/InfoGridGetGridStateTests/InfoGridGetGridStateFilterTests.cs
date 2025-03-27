using BlazorWebAppMovies.BusinessLogic.Grid;

namespace BlazorWebAppMovies.BusinessLogic.UnitTests.GridTests.InfoGridTests.InfoGridGetGridStateTests;

public class InfoGridGetGridStateFilterTests : InfoGridTestsBaseClass
{
    [Test]
    public void FilterHello_WhenFilter1Hello()
    {
        var expected = new InfoGrid
        {
            _columnNames = [
                "Completed Date and Time",
                "Is Completed",
                "Ordering",
                "Title",
                "To Do List",
            ],
            _columnTypes = [
                ColumnType.DateTime,
                ColumnType.Boolean,
                ColumnType.Integer,
                ColumnType.Normalized,
                ColumnType.Normalized,
            ],
            _filters = [
                null,
                "Hello",
                null,
                null,
                null,
            ],
            _page = 1,
            _rowsPerPage = 10,
            _sorts = [],
            _totalPages = 3,
            _totalRows = 28,
        };

        _infoGrid.Filter(1, "Hello");
        var actual = _infoGrid;

        Assert.Multiple(() =>
        {
            Assert.That(actual._columnNames, Is.EqualTo(expected._columnNames), $"Columns is {actual._columnNames}, but should be {expected._columnNames}");
            Assert.That(actual._columnTypes, Is.EqualTo(expected._columnTypes), $"Columns is {actual._columnTypes}, but should be {expected._columnTypes}");
            Assert.That(actual._filters, Is.EqualTo(expected._filters), $"Filters is {actual._filters}, but should be {expected._filters}");
            Assert.That(actual._page, Is.EqualTo(expected._page), $"Page is {actual._page}, but should be {expected._page}");
            Assert.That(actual._rowsPerPage, Is.EqualTo(expected._rowsPerPage), $"Rows Per Page is {actual._rowsPerPage}, but should be {expected._rowsPerPage}");
            Assert.That(actual._sorts, Is.EqualTo(expected._sorts), $"Sorts is {actual._sorts}, but should be {expected._sorts}");
            Assert.That(actual._totalPages, Is.EqualTo(expected._totalPages), $"Total Pages is {actual._totalPages}, but should be {expected._totalPages}");
            Assert.That(actual._totalRows, Is.EqualTo(expected._totalRows), $"Total Rows is {actual._totalRows}, but should be {expected._totalRows}");
        });
    }

    [Test]
    public void FilterHello_WhenFilter1HelloNegative1World()
    {
        var expected = new InfoGrid
        {
            _columnNames = [
                "Completed Date and Time",
                "Is Completed",
                "Ordering",
                "Title",
                "To Do List",
            ],
            _columnTypes = [
                ColumnType.DateTime,
                ColumnType.Boolean,
                ColumnType.Integer,
                ColumnType.Normalized,
                ColumnType.Normalized,
            ],
            _filters = [
                null,
                "Hello",
                null,
                null,
                null,
            ],
            _page = 1,
            _rowsPerPage = 10,
            _sorts = [],
            _totalPages = 3,
            _totalRows = 28,
        };

        _infoGrid.Filter(1, "Hello");
        _infoGrid.Filter(-1, "World");
        var actual = _infoGrid;

        Assert.Multiple(() =>
        {
            Assert.That(actual._columnNames, Is.EqualTo(expected._columnNames), $"Columns is {actual._columnNames}, but should be {expected._columnNames}");
            Assert.That(actual._columnTypes, Is.EqualTo(expected._columnTypes), $"Columns is {actual._columnTypes}, but should be {expected._columnTypes}");
            Assert.That(actual._filters, Is.EqualTo(expected._filters), $"Filters is {actual._filters}, but should be {expected._filters}");
            Assert.That(actual._page, Is.EqualTo(expected._page), $"Page is {actual._page}, but should be {expected._page}");
            Assert.That(actual._rowsPerPage, Is.EqualTo(expected._rowsPerPage), $"Rows Per Page is {actual._rowsPerPage}, but should be {expected._rowsPerPage}");
            Assert.That(actual._sorts, Is.EqualTo(expected._sorts), $"Sorts is {actual._sorts}, but should be {expected._sorts}");
            Assert.That(actual._totalPages, Is.EqualTo(expected._totalPages), $"Total Pages is {actual._totalPages}, but should be {expected._totalPages}");
            Assert.That(actual._totalRows, Is.EqualTo(expected._totalRows), $"Total Rows is {actual._totalRows}, but should be {expected._totalRows}");
        });
    }

    [Test]
    public void FilterHello_WhenFilter1Hello5World()
    {
        var expected = new InfoGrid
        {
            _columnNames = [
                "Completed Date and Time",
                "Is Completed",
                "Ordering",
                "Title",
                "To Do List",
            ],
            _columnTypes = [
                ColumnType.DateTime,
                ColumnType.Boolean,
                ColumnType.Integer,
                ColumnType.Normalized,
                ColumnType.Normalized,
            ],
            _filters = [
                null,
                "Hello",
                null,
                null,
                null,
            ],
            _page = 1,
            _rowsPerPage = 10,
            _sorts = [],
            _totalPages = 3,
            _totalRows = 28,
        };

        _infoGrid.Filter(1, "Hello");
        _infoGrid.Filter(5, "World");
        var actual = _infoGrid;

        Assert.Multiple(() =>
        {
            Assert.That(actual._columnNames, Is.EqualTo(expected._columnNames), $"Columns is {actual._columnNames}, but should be {expected._columnNames}");
            Assert.That(actual._columnTypes, Is.EqualTo(expected._columnTypes), $"Columns is {actual._columnTypes}, but should be {expected._columnTypes}");
            Assert.That(actual._filters, Is.EqualTo(expected._filters), $"Filters is {actual._filters}, but should be {expected._filters}");
            Assert.That(actual._page, Is.EqualTo(expected._page), $"Page is {actual._page}, but should be {expected._page}");
            Assert.That(actual._rowsPerPage, Is.EqualTo(expected._rowsPerPage), $"Rows Per Page is {actual._rowsPerPage}, but should be {expected._rowsPerPage}");
            Assert.That(actual._sorts, Is.EqualTo(expected._sorts), $"Sorts is {actual._sorts}, but should be {expected._sorts}");
            Assert.That(actual._totalPages, Is.EqualTo(expected._totalPages), $"Total Pages is {actual._totalPages}, but should be {expected._totalPages}");
            Assert.That(actual._totalRows, Is.EqualTo(expected._totalRows), $"Total Rows is {actual._totalRows}, but should be {expected._totalRows}");
        });
    }
}
