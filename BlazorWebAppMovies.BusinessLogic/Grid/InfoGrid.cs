namespace BlazorWebAppMovies.BusinessLogic.Grid;

public class InfoGrid<T>(List<T> info)
{
    public List<T> _info = info;
    public InfoGridState _infoGridState = new();
}
