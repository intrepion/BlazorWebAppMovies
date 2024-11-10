using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using BlazorWebAppMovies.BusinessLogic.Entities;

namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.MovieGrid;

// Creates the correct expressions to filter and sort.
public class MovieGridQueryAdapter
{
    // Holds state of the grid.
    private readonly IMovieFilters controls;

    // Expressions for sorting.
    private readonly Dictionary<MovieFilterColumns, Expression<Func<Movie, string>>> expressions =
        new()
        {
            { MovieFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            // SortExpressionCodePlaceholder
        };

    // Queryables for filtering.
    private readonly Dictionary<MovieFilterColumns, Func<IQueryable<Movie>, IQueryable<Movie>>> filterQueries = [];

    // Creates a new instance of the GridQueryAdapter class.
    // controls: The IMovieFilters" to use.
    public MovieGridQueryAdapter(IMovieFilters controls)
    {
        this.controls = controls;

        // Set up queries.
        filterQueries =
            new()
            {
                { MovieFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
            };
    }

    // Uses the query to return a count and a page.
    // query: The IQueryable{Movie} to work from.
    // Returns the resulting ICollection{Movie}.
    public async Task<ICollection<Movie>> FetchAsync(IQueryable<Movie> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    // Get total filtered items count.
    // query: The IQueryable{Movie} to use.
    public async Task CountAsync(IQueryable<Movie> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    // Build the query to bring back a single page.
    // query: The <see IQueryable{Movie} to modify.
    // Returns the new IQueryable{Movie} for a page.
    public IQueryable<Movie> FetchPageQuery(IQueryable<Movie> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    // Builds the query.
    // root: The IQueryable{Movie} to start with.
    // Returns the resulting IQueryable{Movie} with sorts and filters applied.
    private IQueryable<Movie> FilterAndQuery(IQueryable<Movie> root)
    {
        var sb = new System.Text.StringBuilder();

        // Apply a filter?
        if (!string.IsNullOrWhiteSpace(controls.FilterText))
        {
            var filter = filterQueries[controls.FilterColumn];
            sb.Append($"Filter: '{controls.FilterColumn}' ");
            root = filter(root);
        }

        // Apply the expression.
        var expression = expressions[controls.SortColumn];
        sb.Append($"Sort: '{controls.SortColumn}' ");

        var sortDir = controls.SortAscending ? "ASC" : "DESC";
        sb.Append(sortDir);

        Debug.WriteLine(sb.ToString());

        // Return the unfiltered query for total count, and the filtered for fetching.
        return controls.SortAscending ? root.OrderBy(expression) : root.OrderByDescending(expression);
    }
}
