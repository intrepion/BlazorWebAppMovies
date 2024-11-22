using System.Diagnostics;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using BlazorWebAppMovies.BusinessLogic.Entities;

namespace BlazorWebAppMovies.BusinessLogic.Grid.Admin.CastMemberGrid;

public class CastMemberGridQueryAdapter
{
    private readonly ICastMemberFilters controls;

    private readonly Dictionary<CastMemberFilterColumns, Expression<Func<CastMember, string>>> expressions =
        new()
        {
            { CastMemberFilterColumns.Id, x => !x.Id.Equals(Guid.Empty) ? x.Id.ToString() : string.Empty },

            { CastMemberFilterColumns.Name1, x => x != null && x.Name1 != null ? x.Name1 : string.Empty },
            // SortExpressionCodePlaceholder
        };

    private readonly Dictionary<CastMemberFilterColumns, Func<IQueryable<CastMember>, IQueryable<CastMember>>> filterQueries = [];

    public CastMemberGridQueryAdapter(ICastMemberFilters controls)
    {
        this.controls = controls;

        filterQueries =
            new()
            {
                { CastMemberFilterColumns.Id, x => x.Where(y => y != null && !y.Id.Equals(Guid.Empty) && this.controls.FilterText != null && y.Id.ToString().Contains(this.controls.FilterText) ) },

                // QueryExpressionCodePlaceholder
            };
    }

    public async Task<ICollection<CastMember>> FetchAsync(IQueryable<CastMember> query)
    {
        query = FilterAndQuery(query);
        await CountAsync(query);
        var collection = await FetchPageQuery(query).ToListAsync();
        controls.PageHelper.PageItems = collection.Count;
        return collection;
    }

    public async Task CountAsync(IQueryable<CastMember> query) =>
        controls.PageHelper.TotalItemCount = await query.CountAsync();

    public IQueryable<CastMember> FetchPageQuery(IQueryable<CastMember> query) =>
        query
            .Skip(controls.PageHelper.Skip)
            .Take(controls.PageHelper.PageSize)
            .AsNoTracking();

    private IQueryable<CastMember> FilterAndQuery(IQueryable<CastMember> root)
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
