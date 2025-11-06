using DiagramPersistenceServiceApi.Domain.Model;
using DiagramPersistenceServiceApi.Domain.Service;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Classes.AddClassToDiagram;

public class AddClassToDiagramAction : IAction<AddClassToDiagramCommand, UmlClass>
{
    private readonly IDiagramsDomainService _diagramsDomainService;

    public AddClassToDiagramAction(IDiagramsDomainService diagramsDomainService)
    {
        _diagramsDomainService = diagramsDomainService;
    }

    public async Task<UmlClass> ExecuteAsync(AddClassToDiagramCommand command, CancellationToken ct)
    {
        var position = new UmlPosition(command.PositionX, command.PositionY);
        var umlClass = await _diagramsDomainService.CreateClassAsync(
            command.DiagramId,
            command.ClassName,
            position,
            ct
        );
        return umlClass;
    }
}
