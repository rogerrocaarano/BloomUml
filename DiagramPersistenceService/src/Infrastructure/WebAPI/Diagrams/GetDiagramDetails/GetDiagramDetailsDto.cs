namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Diagrams.GetDiagramDetails;

public abstract class GetDiagramDetailsDto
{
    public record Response(
        Guid DiagramId,
        Guid OwnerId,
        string Name,
        int Version,
        DateTime VersioningDateTime,
        ICollection<Guid> ClassesIds,
        ICollection<Guid> RelationsIds
    );
}
