using Microsoft.AspNetCore.Components;

namespace BlazorWebAppMovies.Shared.Grid;

public partial class InfoGrid
{
    [Parameter]
    public List<string> ColumnNames { get; set; } = [];
    [Parameter]
    public List<ColumnType> ColumnTypes { get; set; } = [];
    [Parameter]
    public List<string?> Filters { get; set; } = [];
    [Parameter]
    public List<List<string>> Info { get; set; } = [];
    [Parameter]
    public int Page { get; set; } = 0;
    [Parameter]
    public int RowsPerPage { get; set; } = 10;
    [Parameter]
    public List<(int, bool)> Sorts { get; set; } = [];
    [Parameter]
    public int TotalPages { get; set; } = 0;
    [Parameter]
    public int TotalRows { get; set; } = 0;

    public void SetFilter(int column, string? filter)
    {
        if (column < 0)
        {
            return;
        }

        if (column >= ColumnTypes.Count)
        {
            return;
        }

        Filters[column] = filter;
    }

    public void NextPage()
    {
        var nextPage = Page + 1;

        if (nextPage <= TotalPages)
        {
            Page = nextPage;
        }
    }

    public void PreviousPage()
    {
        var previousPage = Page - 1;

        if (previousPage >= 1)
        {
            Page = previousPage;
        }
    }

    public void SetRowsPerPage(int rowsPerPage)
    {
        RowsPerPage = rowsPerPage;

        if ((Info.Count % RowsPerPage) == 0)
        {
            TotalPages = Info.Count / RowsPerPage;
        }
        else
        {
            TotalPages = (Info.Count / RowsPerPage) + 1;
        }

        TotalRows = Info.Count;
    }

    public void SetInitialInfo(List<string> columnNames, List<ColumnType> columnTypes, List<List<string>> info)
    {
        ColumnNames = columnNames;
        ColumnTypes = columnTypes;
        Info = info;
        Filters = [.. Enumerable.Repeat<string?>(null, columnNames.Count)];

        if (info.Count > 0)
        {
            Page = 1;
        }

        SetRowsPerPage(10);
    }

    public void SetSort(int column)
    {
        if (column < 0)
        {
            return;
        }

        if (column >= ColumnTypes.Count)
        {
            return;
        }

        var found = -1;
        var n = Sorts.Count;

        for (var i = 0; i < n; i += 1)
        {
            if (Sorts[i].Item1 == column)
            {
                found = i;
            }
        }

        if (found == -1)
        {
            Sorts.Insert(0, (column, true));

            return;
        }

        if (Sorts[found].Item2)
        {
            Sorts[found] = (column, false);

            return;
        }

        Sorts.RemoveAt(found);
    }
}
