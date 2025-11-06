using DiagramPersistenceServiceApi.Domain.Model;
using DiagramPersistenceServiceApi.Domain.Service;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Diagrams.GetDiagram;

public class GetDiagramAction : IAction<GetDiagramCommand, UmlDiagram>
{
    private readonly IDiagramsDomainService _diagramsDomainService;

    public GetDiagramAction(IDiagramsDomainService diagramsDomainService)
    {
        _diagramsDomainService = diagramsDomainService;
    }

    public async Task<UmlDiagram> ExecuteAsync(GetDiagramCommand command, CancellationToken ct)
    {
        return await _diagramsDomainService.GetDiagramAsync(command.DiagramId, ct);
    }
}
