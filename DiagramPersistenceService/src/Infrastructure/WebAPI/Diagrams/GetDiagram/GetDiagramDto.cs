namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Diagrams.GetDiagram;

public abstract class GetDiagramDto
{
    public record Response(
        Guid DiagramId,
        Guid OwnerId,
        string Name,
        int Version,
        DateTime VersioningDateTime
    );
}
