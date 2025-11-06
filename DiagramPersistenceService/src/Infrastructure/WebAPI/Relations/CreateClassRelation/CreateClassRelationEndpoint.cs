using DiagramPersistenceServiceApi.Application.Actions.Relations.CreateClassRelation;
using DiagramPersistenceServiceApi.Domain.Model;
using FastEndpoints;

namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Relations.CreateClassRelation;

public class CreateClassRelationEndpoint
    : Endpoint<CreateClassRelationDto.Request, CreateClassRelationDto.Response>
{
    public required CreateClassRelationAction CreateClassRelationAction { get; set; }

    public override void Configure()
    {
        Post("relations");
        // TODO: Add proper authentication and authorization
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateClassRelationDto.Request req, CancellationToken ct)
    {
        var command = new CreateClassRelationCommand(
            req.DiagramId,
            req.FromClassId,
            req.ToClassId,
            req.RelationType,
            req.Bidirectional,
            req.MultiplicityOrigin,
            req.MultiplicityDestination
        );
        UmlClassRelation? relation = await CreateClassRelationAction.ExecuteAsync(command, ct);

        if (relation != null)
        {
            await Send.OkAsync(new(RelationId: relation.Id), ct);
        }
        else
        {
            // TODO: Handle failure case properly
            await Send.NoContentAsync(ct);
        }
    }
}
