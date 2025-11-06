namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Diagrams.GetDiagramsByOwner;

public abstract class GetDiagramsByOwnerDto
{
    public record DiagramSummary(
        Guid DiagramId,
        string Name,
        int Version,
        DateTime VersioningDateTime
    );

    public record Response(ICollection<DiagramSummary> Diagrams);
}
