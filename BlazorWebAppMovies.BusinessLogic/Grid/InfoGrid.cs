namespace BlazorWebAppMovies.BusinessLogic.Grid;

public class InfoGrid<T>()
{
    public List<T> _info = [];
    public InfoGridState _infoGridState = new();

    public void SetInitialInfo(List<T> info)
    {
        _info = info;
        _infoGridState._columns = 3;
        if (info.Count > 0)
        {
            _infoGridState._page = 1;
        }

        if ((info.Count % _infoGridState._rowsPerPage) == 0)
        {
            _infoGridState._totalPages = info.Count / _infoGridState._rowsPerPage;
        }
        else
        {
            _infoGridState._totalPages = (info.Count / _infoGridState._rowsPerPage) + 1;
        }
        _infoGridState._totalRows = info.Count;
    }

    public void NextPage()
    {
        if (_infoGridState._page < 1)
        {
            return;
        }

        var nextPage = _infoGridState._page + 1;

        if (nextPage <= _infoGridState._totalPages)
        {
            _infoGridState._page = nextPage;
        }
    }

    public void PreviousPage()
    {
        _infoGridState._page = 1;
    }
}
