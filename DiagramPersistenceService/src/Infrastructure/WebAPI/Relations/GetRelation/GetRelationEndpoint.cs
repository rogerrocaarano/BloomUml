using DiagramPersistenceServiceApi.Application.Actions.Relations.GetRelation;
using DiagramPersistenceServiceApi.Domain.Model;
using FastEndpoints;

namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Relations.GetRelation;

public class GetRelationEndpoint : EndpointWithoutRequest<GetRelationDto.Response>
{
    public required GetRelationAction GetRelationAction { get; set; }

    public override void Configure()
    {
        Get("relations/{RelationId}");
        // TODO: Add proper authentication and authorization
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var relationId = Route<Guid>("RelationId");
        var command = new GetRelationCommand(relationId);
        UmlClassRelation relation = await GetRelationAction.ExecuteAsync(command, ct);

        var response = new GetRelationDto.Response(
            RelationId: relation.Id,
            DiagramId: relation.DiagramId,
            Direction: new GetRelationDto.DirectionResponse(
                FromClassId: relation.Direction.FromClassId,
                ToClassId: relation.Direction.ToClassId,
                Bidirectional: relation.Direction.Bidirectional
            ),
            Type: relation.Type.Type,
            Multiplicity: relation.Multiplicity != null
                ? new GetRelationDto.MultiplicityResponse(
                    Origin: relation.Multiplicity.Origin,
                    Destination: relation.Multiplicity.Destination
                )
                : null
        );

        await Send.OkAsync(response, ct);
    }
}
