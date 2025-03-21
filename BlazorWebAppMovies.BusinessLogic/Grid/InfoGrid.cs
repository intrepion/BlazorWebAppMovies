namespace BlazorWebAppMovies.BusinessLogic.Grid;

public class InfoGrid<T>()
{
    public int _columns = 0;
    public List<string?> _filters = [];
    public List<T> _info = [];
    public int _page = 0;
    public int _rowsPerPage = 10;
    public List<(int, bool)> _sorts = [];
    public int _totalPages = 0;
    public int _totalRows = 0;

    public void Filter(int column, string? filter)
    {
        _filters[column - 1] = filter;
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

    public void SetInitialInfo(List<T> info)
    {
        _info = info;
        _columns = 3;
        _filters = [
            null,
            null,
            null,
        ];

        if (info.Count > 0)
        {
            _page = 1;
        }

        if ((info.Count % _rowsPerPage) == 0)
        {
            _totalPages = info.Count / _rowsPerPage;
        }
        else
        {
            _totalPages = (info.Count / _rowsPerPage) + 1;
        }
        _totalRows = info.Count;
    }

    public void Sort(int column)
    {
        if (column < 1)
        {
            return;
        }

        if (column > _columns)
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
