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
    public List<Guid>? Ids { get; set; } = [];
    [Parameter]
    public List<List<string>>? Info { get; set; } = [];
    [Parameter]
    public int Page { get; set; } = 1;
    [Parameter]
    public int RowsPerPage { get; set; } = 10;
    [Parameter]
    public List<(int, bool)> Sorts { get; set; } = [];
    [Parameter]
    public int TotalPages { get; set; } = 0;
    [Parameter]
    public int TotalRows { get; set; } = 0;
    [Parameter]
    public string UrlName { get; set; } = string.Empty;
    [Parameter]
    public EventCallback<int> OnPageChanged { get; set; }

    protected override void OnParametersSet()
    {
        if (ColumnNames.Count > 0 && Filters.Count == 0)
        {
            Filters = [.. Enumerable.Repeat<string?>(null, ColumnNames.Count)];
        }

        SetRowsPerPage(RowsPerPage);
    }

    public void SetFilter(int column, string? filter)
    {
        if (column < 0 || column >= ColumnTypes.Count)
        {
            return;
        }

        Filters[column] = filter;
    }

    public async Task NextPage()
    {
        var nextPage = Page + 1;

        if (nextPage <= TotalPages)
        {
            await OnPageChanged.InvokeAsync(nextPage);
        }
    }

    public async Task PreviousPage()
    {
        var previousPage = Page - 1;

        if (previousPage >= 1)
        {
            await OnPageChanged.InvokeAsync(previousPage);
        }
    }

    public void SetRowsPerPage(int rowsPerPage)
    {
        RowsPerPage = rowsPerPage;
    }

    public void SetSort(int column)
    {
        if (column < 0 || column >= ColumnTypes.Count)
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
