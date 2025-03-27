namespace BlazorWebAppMovies.BusinessLogic.Grid;

public class InfoGrid()
{
    public List<string> _columnNames = [];
    public List<ColumnType> _columnTypes = [];
    public List<string?> _filters = [];
    public List<List<string>> _info = [];
    public int _page = 0;
    public int _rowsPerPage = 10;
    public List<(int, bool)> _sorts = [];
    public int _totalPages = 0;
    public int _totalRows = 0;

    public void Filter(int column, string? filter)
    {
        if (column < 0)
        {
            return;
        }

        if (column >= _columnTypes.Count)
        {
            return;
        }

        _filters[column] = filter;
    }

    public void NextPage()
    {
        var nextPage = _page + 1;

        if (nextPage <= _totalPages)
        {
            _page = nextPage;
        }
    }

    public void PreviousPage()
    {
        var previousPage = _page - 1;

        if (previousPage >= 1)
        {
            _page = previousPage;
        }
    }

    public void RowsPerPage(int rowsPerPage)
    {
        _rowsPerPage = rowsPerPage;

        if ((_info.Count % _rowsPerPage) == 0)
        {
            _totalPages = _info.Count / _rowsPerPage;
        }
        else
        {
            _totalPages = (_info.Count / _rowsPerPage) + 1;
        }

        _totalRows = _info.Count;
    }

    public void SetInitialInfo(List<string> columnNames, List<ColumnType> columnTypes, List<List<string>> info)
    {
        _columnNames = columnNames;
        _columnTypes = columnTypes;
        _info = info;
        _filters = [.. Enumerable.Repeat<string?>(null, columnNames.Count)];

        if (info.Count > 0)
        {
            _page = 1;
        }

        RowsPerPage(10);
    }

    public void Sort(int column)
    {
        if (column < 0)
        {
            return;
        }

        if (column >= _columnTypes.Count)
        {
            return;
        }

        var found = -1;
        var n = _sorts.Count;

        for (var i = 0; i < n; i += 1)
        {
            if (_sorts[i].Item1 == column)
            {
                found = i;
            }
        }

        if (found == -1)
        {
            _sorts.Insert(0, (column, true));

            return;
        }

        if (_sorts[found].Item2)
        {
            _sorts[found] = (column, false);

            return;
        }

        _sorts.RemoveAt(found);
    }
}
