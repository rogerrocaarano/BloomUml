using DiagramPersistenceServiceApi.Domain.Model;
using OpenDDD.Infrastructure.Persistence.OpenDdd.DatabaseSession.InMemory;
using OpenDDD.Infrastructure.Persistence.Serializers;
using OpenDDD.Infrastructure.Repository.OpenDdd.InMemory;

namespace DiagramPersistenceServiceApi.Infrastructure.Repositories;

public class UmlClassRelationsRepository
    : InMemoryOpenDddRepository<UmlClassRelation, Guid>,
        IUmlClassRelationsRepository
{
    public UmlClassRelationsRepository(
        InMemoryDatabaseSession session,
        IAggregateSerializer serializer
    )
        : base(session, serializer) { }
}
