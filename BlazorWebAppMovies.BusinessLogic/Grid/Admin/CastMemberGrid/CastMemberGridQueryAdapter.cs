using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using BlazorWebAppMovies.BusinessLogic.Entities;

namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.CastMemberGrid;

// Creates the correct expressions to filter and sort.
public class CastMemberGridQueryAdapter
{
    // Holds state of the grid.
    private readonly ICastMemberFilters controls;

    // Expressions for sorting.
    private readonly Dictionary<CastMemberFilterColumns, Expression<Func<CastMember, string>>> expressions =
        new()
        {
            { CastMemberFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            // SortExpressionCodePlaceholder
        };

    // Queryables for filtering.
    private readonly Dictionary<CastMemberFilterColumns, Func<IQueryable<CastMember>, IQueryable<CastMember>>> filterQueries = [];

    // Creates a new instance of the GridQueryAdapter class.
    // controls: The ICastMemberFilters" to use.
    public CastMemberGridQueryAdapter(ICastMemberFilters controls)
    {
        this.controls = controls;

        // Set up queries.
        filterQueries =
            new()
            {
                { CastMemberFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
            };
    }

    // Uses the query to return a count and a page.
    // query: The IQueryable{CastMember} to work from.
    // Returns the resulting ICollection{CastMember}.
    public async Task<ICollection<CastMember>> FetchAsync(IQueryable<CastMember> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    // Get total filtered items count.
    // query: The IQueryable{CastMember} to use.
    public async Task CountAsync(IQueryable<CastMember> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    // Build the query to bring back a single page.
    // query: The <see IQueryable{CastMember} to modify.
    // Returns the new IQueryable{CastMember} for a page.
    public IQueryable<CastMember> FetchPageQuery(IQueryable<CastMember> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    // Builds the query.
    // root: The IQueryable{CastMember} to start with.
    // Returns the resulting IQueryable{CastMember} with sorts and filters applied.
    private IQueryable<CastMember> FilterAndQuery(IQueryable<CastMember> root)
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
