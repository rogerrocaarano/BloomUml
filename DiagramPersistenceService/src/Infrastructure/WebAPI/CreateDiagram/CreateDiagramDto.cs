namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.CreateDiagram;

public abstract class CreateDiagramDto
{
    public record Request(Guid OwnerId, string DiagramName);

    public record Response(Guid DiagramId);
}
