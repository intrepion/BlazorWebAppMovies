namespace BlazorWebAppMovies.BusinessLogic.Grid;

public class InfoGrid<T>()
{
    public int _columns = 0;
    public List<(int, string)> _filters = [];
    public List<T> _info = [];
    public int _page = 0;
    public int _rowsPerPage = 10;
    public List<(int, bool)> _sorts = [];
    public int _totalPages = 0;
    public int _totalRows = 0;

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
        _sorts.Add((column, true));
    }
}
