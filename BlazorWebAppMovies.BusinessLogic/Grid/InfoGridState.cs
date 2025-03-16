namespace BlazorWebAppMovies.BusinessLogic.Grid;

public class InfoGridState
{
    public int _columns = 0;
    public List<(int, string)> _filters = [];
    public int _page = 1;
    public int _rowsPerPage = 10;
    public List<(int, bool)> _sorts = [];
    public int _totalRows = 0;
}
