namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Classes.AddAttributeToClass;

public abstract class AddAttributeToClassDto
{
    public record Request(
        Guid ClassId,
        string Visibility,
        string AttributeName,
        string AttributeType
    );

    public record Response(Guid AttributeId);
}
