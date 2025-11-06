using DiagramPersistenceServiceApi.Domain.Model;
using DiagramPersistenceServiceApi.Domain.Service;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Relations.GetRelation;

public class GetRelationAction : IAction<GetRelationCommand, UmlClassRelation>
{
    private readonly IDiagramsDomainService _diagramsDomainService;

    public GetRelationAction(IDiagramsDomainService diagramsDomainService)
    {
        _diagramsDomainService = diagramsDomainService;
    }

    public async Task<UmlClassRelation> ExecuteAsync(
        GetRelationCommand command,
        CancellationToken ct
    )
    {
        return await _diagramsDomainService.GetRelationAsync(command.RelationId, ct);
    }
}
