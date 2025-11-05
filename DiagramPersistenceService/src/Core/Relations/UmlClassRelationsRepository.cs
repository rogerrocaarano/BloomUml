using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace Core.Relations;

public class UmlClassRelationsRepository : IRepository<UmlClassRelation, Guid>
{
    private readonly ConcurrentDictionary<Guid, UmlClassRelation> _relations = new();

    public Task DeleteAsync(UmlClassRelation aggregateRoot, CancellationToken ct)
    {
        _relations.TryRemove(aggregateRoot.Id, out _);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<UmlClassRelation>> FindAllAsync(CancellationToken ct)
    {
        return Task.FromResult<IEnumerable<UmlClassRelation>>(_relations.Values);
    }

    public Task<UmlClassRelation?> FindAsync(Guid id, CancellationToken ct)
    {
        _relations.TryGetValue(id, out var relation);
        return Task.FromResult(relation);
    }

    public Task<IEnumerable<UmlClassRelation>> FindWithAsync(
        Expression<Func<UmlClassRelation, bool>> filterExpression,
        CancellationToken ct
    )
    {
        var compiledFilter = filterExpression.Compile();
        var filteredRelations = _relations.Values.Where(compiledFilter);
        return Task.FromResult(filteredRelations);
    }

    public async Task<UmlClassRelation> GetAsync(Guid id, CancellationToken ct)
    {
        var relation =
            await FindAsync(id, ct)
            ?? throw new KeyNotFoundException($"UmlClassRelation with id {id} not found");
        return relation;
    }

    public Task SaveAsync(UmlClassRelation aggregateRoot, CancellationToken ct)
    {
        aggregateRoot.UpdatedAt = DateTime.UtcNow;
        _relations[aggregateRoot.Id] = aggregateRoot;
        return Task.CompletedTask;
    }
}
