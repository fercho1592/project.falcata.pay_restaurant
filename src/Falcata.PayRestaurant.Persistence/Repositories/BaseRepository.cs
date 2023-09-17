using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Falcata.PayRestaurant.Application.Interfaces.QueryBuilders;
using Falcata.PayRestaurant.Application.Interfaces.Repositories;
using Falcata.PayRestaurant.Domain.Models;
using Falcata.PayRestaurant.Persistence.Contexts;
using Falcata.PayRestaurant.Persistence.QueryBuilder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Falcata.PayRestaurant.Persistence.Repositories;

public abstract class BaseRepository<TEntity, TKey, TDbContext>: 
    IQueryRepository<TEntity, TKey>,
    ICreateCommandRepository<TEntity, TKey>,
    IUpdateCommandRepository<TEntity, TKey>,
    IDeleteCommandRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
    where TDbContext : IBaseDbContext
{
    protected readonly TDbContext _context;
    private readonly ILogger _logger;
    protected abstract DbSet<TEntity> Entities { get; }

    protected BaseRepository([DisallowNull] TDbContext context, ILogger logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    
    private async Task<List<TEntity>> ExecuteListAsync(IQueryable<TEntity> query,
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

        (IQueryable<TEntity> query, Expression<Func<TEntity, bool>>? predicate) = (queryBuilder as BaseQueryBuilder<TEntity>)!.GetQuery();
        return await ExecuteListAsync(query, predicate, cancellationToken);
    }

    public async Task<bool> CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var trackedEntity = Entities.Add(entity);

        await _context.ExecuteSaveChangesAsync(cancellationToken);

        return trackedEntity.State == EntityState.Added;
    }

    public async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        
        var trackedEntity = Entities.Update(entity);

        var initialState = trackedEntity.State;
        await _context.ExecuteSaveChangesAsync(cancellationToken);

        return trackedEntity.State == EntityState.Unchanged && initialState == EntityState.Modified; 
    }

    public async Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        var trackedEntity = Entities.Remove(entity);
        
        await _context.ExecuteSaveChangesAsync(cancellationToken);

        return trackedEntity.State == EntityState.Deleted;
    }
}