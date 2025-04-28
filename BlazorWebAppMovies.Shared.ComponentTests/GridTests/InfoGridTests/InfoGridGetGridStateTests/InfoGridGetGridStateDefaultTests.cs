using BlazorWebAppMovies.Shared.Grid;

namespace BlazorWebAppMovies.Shared.UnitTests.GridTests.InfoGridTests.InfoGridGetGridStateTests;

public class InfoGridGetGridStateDefaultTests : InfoGridTestsBaseClass
{
    [Test]
    public void DefaultState_WhenNothing()
    {
        var columnNames = new List<string>
        {
            "Completed Date and Time",
            "Is Completed",
            "Ordering",
            "Title",
            "To Do List",
        };

        var columnTypes = new List<ColumnType>
        {
            ColumnType.DateTime,
            ColumnType.Boolean,
            ColumnType.Integer,
            ColumnType.Normalized,
            ColumnType.Normalized,
        };

        var filters = new List<string?>
        {
            null,
            null,
            null,
            null,
            null,
        };

        var page = 1;
        var rowsPerPage = 10;
        var sorts = new List<(int, bool)>();
        var totalPages = 3;
        var totalRows = 28;

        _infoGrid.ColumnNames = columnNames;
        _infoGrid.ColumnTypes = columnTypes;
        _infoGrid.Filters = filters;
        _infoGrid.Page = page;
        _infoGrid.RowsPerPage = rowsPerPage;
        _infoGrid.Sorts = sorts;
        _infoGrid.TotalPages = totalPages;
        _infoGrid.TotalRows = totalRows;
        var actual = _infoGrid;

        Assert.Multiple(() =>
        {
            Assert.That(actual.ColumnNames, Is.EqualTo(columnNames), $"Columns is {actual.ColumnNames}, but should be {columnNames}");
            Assert.That(actual.ColumnTypes, Is.EqualTo(columnTypes), $"Columns is {actual.ColumnTypes}, but should be {columnTypes}");
            Assert.That(actual.Filters, Is.EqualTo(filters), $"Filters is {actual.Filters}, but should be {filters}");
            Assert.That(actual.Page, Is.EqualTo(page), $"Page is {actual.Page}, but should be {page}");
            Assert.That(actual.RowsPerPage, Is.EqualTo(rowsPerPage), $"Rows Per Page is {actual.RowsPerPage}, but should be {rowsPerPage}");
            Assert.That(actual.Sorts, Is.EqualTo(sorts), $"Sorts is {actual.Sorts}, but should be {sorts}");
            Assert.That(actual.TotalPages, Is.EqualTo(totalPages), $"Total Pages is {actual.TotalPages}, but should be {totalPages}");
            Assert.That(actual.TotalRows, Is.EqualTo(totalRows), $"Total Rows is {actual.TotalRows}, but should be {totalRows}");
        });
    }
}
