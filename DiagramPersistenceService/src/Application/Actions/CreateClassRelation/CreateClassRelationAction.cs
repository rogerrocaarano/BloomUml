using DiagramPersistenceServiceApi.Domain.Model;
using DiagramPersistenceServiceApi.Domain.Service;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.CreateClassRelation;

public class CreateClassRelationAction : IAction<CreateClassRelationCommand, UmlClassRelation>
{
    private readonly IDiagramsDomainService _diagramsDomainService;

    public CreateClassRelationAction(IDiagramsDomainService diagramsDomainService)
    {
        _diagramsDomainService = diagramsDomainService;
    }

    public async Task<UmlClassRelation> ExecuteAsync(
        CreateClassRelationCommand command,
        CancellationToken ct
    )
    {
        var relationType = command.RelationType.ToLower() switch
        {
            "inheritance" => UmlClassRelationType.Inheritance,
            "composition" => UmlClassRelationType.Composition,
            "aggregation" => UmlClassRelationType.Aggregation,
            "association" => UmlClassRelationType.Association,
            "dependency" => UmlClassRelationType.Dependency,
            "realization" => UmlClassRelationType.Realization,
            _ => throw new ArgumentException($"Invalid relation type: {command.RelationType}"),
        };

        var relation = await _diagramsDomainService.CreateClassRelationAsync(
            command.DiagramId,
            command.FromClassId,
            command.ToClassId,
            relationType,
            command.Bidirectional,
            command.MultiplicityOrigin,
            command.MultiplicityDestination,
            ct
        );
        return relation;
    }
}
