using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace Core.Classes;

public class UmlClassesRepository : IRepository<UmlClass, Guid>
{
    private readonly ConcurrentDictionary<Guid, UmlClass> _classes = new();

    public Task DeleteAsync(UmlClass aggregateRoot, CancellationToken ct)
    {
        _classes.TryRemove(aggregateRoot.Id, out _);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<UmlClass>> FindAllAsync(CancellationToken ct)
    {
        return Task.FromResult<IEnumerable<UmlClass>>(_classes.Values);
    }

    public Task<UmlClass?> FindAsync(Guid id, CancellationToken ct)
    {
        _classes.TryGetValue(id, out var umlClass);
        return Task.FromResult(umlClass);
    }

    public Task<IEnumerable<UmlClass>> FindWithAsync(
        Expression<Func<UmlClass, bool>> filterExpression,
        CancellationToken ct
    )
    {
        var compiledFilter = filterExpression.Compile();
        var filteredClasses = _classes.Values.Where(compiledFilter);
        return Task.FromResult(filteredClasses);
    }

    public async Task<UmlClass> GetAsync(Guid id, CancellationToken ct)
    {
        var umlClass =
            await FindAsync(id, ct)
            ?? throw new KeyNotFoundException($"UmlClass with id {id} not found");
        return umlClass;
    }

    public Task SaveAsync(UmlClass aggregateRoot, CancellationToken ct)
    {
        aggregateRoot.UpdatedAt = DateTime.UtcNow;
        _classes[aggregateRoot.Id] = aggregateRoot;
        return Task.CompletedTask;
    }
}
