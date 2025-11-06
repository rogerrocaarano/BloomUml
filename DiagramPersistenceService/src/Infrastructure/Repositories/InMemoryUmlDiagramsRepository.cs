using DiagramPersistenceServiceApi.Domain.Model;
using OpenDDD.Infrastructure.Persistence.OpenDdd.DatabaseSession.InMemory;
using OpenDDD.Infrastructure.Persistence.Serializers;
using OpenDDD.Infrastructure.Repository.OpenDdd.InMemory;

namespace DiagramPersistenceServiceApi.Infrastructure.Repositories;

public class InMemoryUmlDiagramsRepository
    : InMemoryOpenDddRepository<UmlDiagram, Guid>,
        IUmlDiagramsRepository
{
    public InMemoryUmlDiagramsRepository(
        InMemoryDatabaseSession session,
        IAggregateSerializer serializer
    )
        : base(session, serializer) { }
}
