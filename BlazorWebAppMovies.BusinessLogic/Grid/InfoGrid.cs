namespace BlazorWebAppMovies.BusinessLogic.Grid;

public class InfoGrid<T>()
{
    public List<T> _info = [];
    public InfoGridState _infoGridState = new();

    public void SetInitialInfo(List<T> info)
    {
        _info = info;
        _infoGridState._columns = 3;
        _infoGridState._totalRows = info.Count;
    }

    public void NextPage()
    {
        var nextPage = _infoGridState._page + 1;

        if (nextPage <= _infoGridState._totalRows / _infoGridState._rowsPerPage)
        {
            _infoGridState._page = nextPage;
        }
    }
}
