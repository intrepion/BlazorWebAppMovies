using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using BlazorWebAppMovies.BusinessLogic.Entities;

namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.CastMemberMovieGrid;

public class CastMemberMovieGridQueryAdapter
{
    private readonly ICastMemberMovieFilters controls;

    private readonly Dictionary<CastMemberMovieFilterColumns, Expression<Func<CastMemberMovie, string>>> expressions =
        new()
        {
            { CastMemberMovieFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            // SortExpressionCodePlaceholder
        };

    private readonly Dictionary<CastMemberMovieFilterColumns, Func<IQueryable<CastMemberMovie>, IQueryable<CastMemberMovie>>> filterQueries = [];

    public CastMemberMovieGridQueryAdapter(ICastMemberMovieFilters controls)
    {
        this.controls = controls;

        filterQueries =
            new()
            {
                { CastMemberMovieFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
            };
    }

    public async Task<ICollection<CastMemberMovie>> FetchAsync(IQueryable<CastMemberMovie> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    public async Task CountAsync(IQueryable<CastMemberMovie> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    public IQueryable<CastMemberMovie> FetchPageQuery(IQueryable<CastMemberMovie> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    private IQueryable<CastMemberMovie> FilterAndQuery(IQueryable<CastMemberMovie> root)
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
