using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace Core.Diagrams;

public class UmlDiagramsRepository : IRepository<UmlDiagram, Guid>
{
    private readonly ConcurrentDictionary<Guid, UmlDiagram> _diagrams = new();

    public Task DeleteAsync(UmlDiagram aggregateRoot, CancellationToken ct)
    {
        _diagrams.TryRemove(aggregateRoot.Id, out _);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<UmlDiagram>> FindAllAsync(CancellationToken ct)
    {
        return Task.FromResult<IEnumerable<UmlDiagram>>(_diagrams.Values);
    }

    public Task<UmlDiagram?> FindAsync(Guid id, CancellationToken ct)
    {
        _diagrams.TryGetValue(id, out var diagram);
        return Task.FromResult(diagram);
    }

    public Task<IEnumerable<UmlDiagram>> FindWithAsync(
        Expression<Func<UmlDiagram, bool>> filterExpression,
        CancellationToken ct
    )
    {
        var compiledFilter = filterExpression.Compile();
        var filteredDiagrams = _diagrams.Values.Where(compiledFilter);
        return Task.FromResult(filteredDiagrams);
    }

    public async Task<UmlDiagram> GetAsync(Guid id, CancellationToken ct)
    {
        var diagram =
            await FindAsync(id, ct)
            ?? throw new KeyNotFoundException($"Diagram with id {id} not found");
        return diagram;
    }

    public Task SaveAsync(UmlDiagram aggregateRoot, CancellationToken ct)
    {
        aggregateRoot.UpdatedAt = DateTime.UtcNow;
        _diagrams[aggregateRoot.Id] = aggregateRoot;
        return Task.CompletedTask;
    }
}
