namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Relations.GetRelation;

public abstract class GetRelationDto
{
    public record DirectionResponse(Guid FromClassId, Guid ToClassId, bool Bidirectional);

    public record MultiplicityResponse(string Origin, string Destination);

    public record Response(
        Guid RelationId,
        Guid DiagramId,
        DirectionResponse Direction,
        string Type,
        MultiplicityResponse? Multiplicity
    );
}
