using DiagramPersistenceServiceApi.Domain.Model;
using DiagramPersistenceServiceApi.Domain.Service;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Classes.AddAttributeToClass;

public class AddAttributeToClassAction : IAction<AddAttributeToClassCommand, UmlAttribute>
{
    private readonly IDiagramsDomainService _diagramsDomainService;

    public AddAttributeToClassAction(IDiagramsDomainService diagramsDomainService)
    {
        _diagramsDomainService = diagramsDomainService;
    }

    public async Task<UmlAttribute> ExecuteAsync(
        AddAttributeToClassCommand command,
        CancellationToken ct
    )
    {
        var visibility = command.Visibility.ToLower() switch
        {
            "public" => UmlVisibility.Public,
            "private" => UmlVisibility.Private,
            "protected" => UmlVisibility.Protected,
            "package" => UmlVisibility.Package,
            _ => throw new ArgumentException($"Invalid visibility: {command.Visibility}"),
        };

        var attribute = await _diagramsDomainService.AddAttributeToClassAsync(
            command.ClassId,
            visibility,
            command.AttributeName,
            command.AttributeType,
            ct
        );
        return attribute;
    }
}
