using System.Linq.Expressions;
using Falcata.PayRestaurant.Application.Interfaces.QueryBuilders;
using Falcata.PayRestaurant.Application.Interfaces.Repositories;
using Falcata.PayRestaurant.Domain.Models;
using Falcata.PayRestaurant.Persistence.QueryBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Falcata.PayRestaurant.Persistence.Repositories;

public abstract class BaseRepository<TEntity, TKey>: 
    IQueryRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    private readonly ILogger _logger;
    protected abstract DbSet<TEntity> Entities { get; }

    protected BaseRepository(ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    public async Task<List<TEntity>> ExecuteListAsync(IQueryable<TEntity> query,
        Expression<Func<TEntity, bool>>? predicate ,CancellationToken cancellationToken)
    {
        _logger.LogDebug($"Executing ListAsync for entity {nameof(TEntity)}");
        if (predicate is not null)
            query = query.Where(predicate);
        
        //Order by

        var result = await query.ToListAsync(cancellationToken);
        _logger.LogDebug($"Number or registers found: {result.Count}");

        return result;
    }

    public async Task<List<TEntity>> ListAsync(IQueryBuilder<TEntity> queryBuilder, CancellationToken cancellationToken)
    {
        if (queryBuilder is null)
            throw new ArgumentNullException(nameof(IQueryBuilder<TEntity>), $"{nameof(queryBuilder)} cannot be null");

        (IQueryable<TEntity> query, Expression<Func<TEntity, bool>>? predicate) = (queryBuilder as BaseQueryBuilder<TEntity>).GetQuery();
        return await ExecuteListAsync(query, predicate, cancellationToken);
    }
}