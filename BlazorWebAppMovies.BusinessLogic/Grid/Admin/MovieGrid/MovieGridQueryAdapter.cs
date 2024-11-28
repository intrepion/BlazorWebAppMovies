using System.Diagnostics;
using System.Linq.Expressions;
using BlazorWebAppMovies.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.MovieGrid;

public class MovieGridQueryAdapter
{
    private readonly IMovieFilters controls;

    private readonly Dictionary<MovieFilterColumns, Expression<Func<Movie, string>>> expressions =
        new()
        {
            { MovieFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            { MovieFilterColumns.Title, x => x != null && x.Title != null ? x.Title : string.Empty },
            { MovieFilterColumns.Year, x => x != null && x.Year != null ? x.Year : string.Empty },
            // SortExpressionCodePlaceholder
        };

    private readonly Dictionary<MovieFilterColumns, Func<IQueryable<Movie>, IQueryable<Movie>>> filterQueries = [];

    public MovieGridQueryAdapter(IMovieFilters controls)
    {
        this.controls = controls;

        filterQueries =
            new()
            {
                { MovieFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
            };
    }

    public async Task<ICollection<Movie>> FetchAsync(IQueryable<Movie> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    public async Task CountAsync(IQueryable<Movie> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    public IQueryable<Movie> FetchPageQuery(IQueryable<Movie> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    private IQueryable<Movie> FilterAndQuery(IQueryable<Movie> root)
    {
        var sb = new System.Text.StringBuilder();

        if (!string.IsNullOrWhiteSpace(controls.FilterText))
        {
            var filter = filterQueries[controls.FilterColumn];
            sb.Append($"Filter: '{controls.FilterColumn}' ");
            root = filter(root);
        }

        var expression = expressions[controls.SortColumn];
        sb.Append($"Sort: '{controls.SortColumn}' ");

        var sortDir = controls.SortAscending ? "ASC" : "DESC";
        sb.Append(sortDir);

        Debug.WriteLine(sb.ToString());

        return controls.SortAscending ? root.OrderBy(expression) : root.OrderByDescending(expression);
    }
}
