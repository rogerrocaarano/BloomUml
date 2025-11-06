namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Classes.GetClass;

public abstract class GetClassDto
{
    public record AttributeResponse(Guid AttributeId, string Visibility, string Name, string Type);

    public record MethodResponse(Guid MethodId, string Visibility, string Name, string ReturnType);

    public record Response(
        Guid ClassId,
        Guid DiagramId,
        string Name,
        int PositionX,
        int PositionY,
        ICollection<AttributeResponse> Attributes,
        ICollection<MethodResponse> Methods
    );
}
