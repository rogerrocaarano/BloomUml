namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Classes.AddClassToDiagram;

public abstract class AddClassToDiagramDto
{
    public record Request(Guid DiagramId, string ClassName, int PositionX, int PositionY);

    public record Response(Guid ClassId);
}
