namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.AddMethodToClass;

public abstract class AddMethodToClassDto
{
    public record Request(Guid ClassId, string Visibility, string MethodName, string ReturnType);

    public record Response(Guid MethodId);
}
