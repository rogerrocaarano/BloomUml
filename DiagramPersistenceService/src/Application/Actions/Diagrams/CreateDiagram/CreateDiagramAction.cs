using DiagramPersistenceServiceApi.Domain.Model;
using DiagramPersistenceServiceApi.Domain.Service;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Diagrams.CreateDiagram;

public class CreateDiagramAction : IAction<CreateDiagramCommand, UmlDiagram>
{
    private readonly IDiagramsDomainService _diagramsDomainService;

    public CreateDiagramAction(IDiagramsDomainService diagramsDomainService)
    {
        _diagramsDomainService = diagramsDomainService;
    }

    public async Task<UmlDiagram> ExecuteAsync(CreateDiagramCommand command, CancellationToken ct)
    {
        var diagram = await _diagramsDomainService.CreateDiagramAsync(
            command.OwnerId,
            command.DiagramName,
            ct
        );
        return diagram;
    }
}
