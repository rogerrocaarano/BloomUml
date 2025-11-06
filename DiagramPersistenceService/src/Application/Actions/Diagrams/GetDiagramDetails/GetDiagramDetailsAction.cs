using DiagramPersistenceServiceApi.Domain.Model;
using DiagramPersistenceServiceApi.Domain.Service;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Diagrams.GetDiagramDetails;

public class GetDiagramDetailsAction : IAction<GetDiagramDetailsCommand, UmlDiagram>
{
    private readonly IDiagramsDomainService _diagramsDomainService;

    public GetDiagramDetailsAction(IDiagramsDomainService diagramsDomainService)
    {
        _diagramsDomainService = diagramsDomainService;
    }

    public async Task<UmlDiagram> ExecuteAsync(
        GetDiagramDetailsCommand command,
        CancellationToken ct
    )
    {
        return await _diagramsDomainService.GetDiagramAsync(command.DiagramId, ct);
    }
}
