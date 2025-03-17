namespace BlazorWebAppMovies.BusinessLogic.Grid;

public class InfoGridState
{
    public int _columns = 0;
    public List<(int, string)> _filters = [];
    public int _page = 0;
    public int _rowsPerPage = 10;
    public List<(int, bool)> _sorts = [];
    public int _totalPages = 0;
    public int _totalRows = 0;
}
