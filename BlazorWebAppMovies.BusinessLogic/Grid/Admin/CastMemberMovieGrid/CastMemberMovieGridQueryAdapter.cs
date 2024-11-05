using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using BlazorWebAppMovies.BusinessLogic.Entities;

namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.CastMemberMovieGrid;

// Creates the correct expressions to filter and sort.
public class CastMemberMovieGridQueryAdapter
{
    // Holds state of the grid.
    private readonly ICastMemberMovieFilters controls;

    // Expressions for sorting.
    private readonly Dictionary<CastMemberMovieFilterColumns, Expression<Func<CastMemberMovie, string>>> expressions =
        new()
        {
            { CastMemberMovieFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            // SortExpressionCodePlaceholder
            // { CastMemberMovieFilterColumns.Name, x => x != null && x.Name != null ? x.Name : string.Empty },
        };

    // Queryables for filtering.
    private readonly Dictionary<CastMemberMovieFilterColumns, Func<IQueryable<CastMemberMovie>, IQueryable<CastMemberMovie>>> filterQueries = [];

    // Creates a new instance of the GridQueryAdapter class.
    // controls: The ICastMemberMovieFilters" to use.
    public CastMemberMovieGridQueryAdapter(ICastMemberMovieFilters controls)
    {
        this.controls = controls;

        // Set up queries.
        filterQueries =
            new()
            {
                { CastMemberMovieFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
                // { CastMemberMovieFilterColumns.Name, x => x.Where(y => y != null && y.Name != null && this.controls.FilterText != null && y.Name.Contains(this.controls.FilterText) ) },
            };
    }

    // Uses the query to return a count and a page.
    // query: The IQueryable{CastMemberMovie} to work from.
    // Returns the resulting ICollection{CastMemberMovie}.
    public async Task<ICollection<CastMemberMovie>> FetchAsync(IQueryable<CastMemberMovie> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    // Get total filtered items count.
    // query: The IQueryable{CastMemberMovie} to use.
    public async Task CountAsync(IQueryable<CastMemberMovie> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    // Build the query to bring back a single page.
    // query: The <see IQueryable{CastMemberMovie} to modify.
    // Returns the new IQueryable{CastMemberMovie} for a page.
    public IQueryable<CastMemberMovie> FetchPageQuery(IQueryable<CastMemberMovie> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    // Builds the query.
    // root: The IQueryable{CastMemberMovie} to start with.
    // Returns the resulting IQueryable{CastMemberMovie} with sorts and filters applied.
    private IQueryable<CastMemberMovie> FilterAndQuery(IQueryable<CastMemberMovie> root)
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
