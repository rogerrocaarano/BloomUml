using DiagramPersistenceServiceApi.Domain.Model;
using OpenDDD.Infrastructure.Persistence.OpenDdd.DatabaseSession.InMemory;
using OpenDDD.Infrastructure.Persistence.Serializers;
using OpenDDD.Infrastructure.Repository.OpenDdd.InMemory;

namespace DiagramPersistenceServiceApi.Infrastructure.Repositories;

public class InMemoryUmlClassesRepository
    : InMemoryOpenDddRepository<UmlClass, Guid>,
        IUmlClassesRepository
{
    public InMemoryUmlClassesRepository(
        InMemoryDatabaseSession session,
        IAggregateSerializer serializer
    )
        : base(session, serializer) { }
}
