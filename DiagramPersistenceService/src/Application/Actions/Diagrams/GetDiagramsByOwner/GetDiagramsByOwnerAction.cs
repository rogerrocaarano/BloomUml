using DiagramPersistenceServiceApi.Domain.Model;
using DiagramPersistenceServiceApi.Domain.Service;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Diagrams.GetDiagramsByOwner;

public class GetDiagramsByOwnerAction : IAction<GetDiagramsByOwnerCommand, ICollection<UmlDiagram>>
{
    private readonly IDiagramsDomainService _diagramsDomainService;

    public GetDiagramsByOwnerAction(IDiagramsDomainService diagramsDomainService)
    {
        _diagramsDomainService = diagramsDomainService;
    }

    public async Task<ICollection<UmlDiagram>> ExecuteAsync(
        GetDiagramsByOwnerCommand command,
        CancellationToken ct
    )
    {
        return await _diagramsDomainService.GetDiagramsByOwnerAsync(command.OwnerId, ct);
    }
}
