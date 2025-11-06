using DiagramPersistenceServiceApi.Domain.Model;
using DiagramPersistenceServiceApi.Domain.Service;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Classes.AddMethodToClass;

public class AddMethodToClassAction : IAction<AddMethodToClassCommand, UmlMethod>
{
    private readonly IDiagramsDomainService _diagramsDomainService;

    public AddMethodToClassAction(IDiagramsDomainService diagramsDomainService)
    {
        _diagramsDomainService = diagramsDomainService;
    }

    public async Task<UmlMethod> ExecuteAsync(AddMethodToClassCommand command, CancellationToken ct)
    {
        var visibility = command.Visibility.ToLower() switch
        {
            "public" => UmlVisibility.Public,
            "private" => UmlVisibility.Private,
            "protected" => UmlVisibility.Protected,
            "package" => UmlVisibility.Package,
            _ => throw new ArgumentException($"Invalid visibility: {command.Visibility}"),
        };

        var method = await _diagramsDomainService.AddMethodToClassAsync(
            command.ClassId,
            visibility,
            command.MethodName,
            command.ReturnType,
            null, // Sin parámetros inicialmente
            ct
        );
        return method;
    }
}
