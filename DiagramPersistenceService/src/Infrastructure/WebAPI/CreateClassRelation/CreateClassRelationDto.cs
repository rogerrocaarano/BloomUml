namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.CreateClassRelation;

public abstract class CreateClassRelationDto
{
    public record Request(
        Guid DiagramId,
        Guid FromClassId,
        Guid ToClassId,
        string RelationType,
        bool Bidirectional,
        string? MultiplicityOrigin,
        string? MultiplicityDestination
    );

    public record Response(Guid RelationId);
}
