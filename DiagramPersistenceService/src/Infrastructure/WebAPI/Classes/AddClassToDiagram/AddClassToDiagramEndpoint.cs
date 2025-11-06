using DiagramPersistenceServiceApi.Application.Actions.Classes.AddClassToDiagram;
using DiagramPersistenceServiceApi.Domain.Model;
using FastEndpoints;

namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Classes.AddClassToDiagram;

public class AddClassToDiagramEndpoint
    : Endpoint<AddClassToDiagramDto.Request, AddClassToDiagramDto.Response>
{
    public required AddClassToDiagramAction AddClassToDiagramAction { get; set; }

    public override void Configure()
    {
        Post("diagrams/{DiagramId}/classes");
        // TODO: Add proper authentication and authorization
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddClassToDiagramDto.Request req, CancellationToken ct)
    {
        var command = new AddClassToDiagramCommand(
            req.DiagramId,
            req.ClassName,
            req.PositionX,
            req.PositionY
        );
        UmlClass? umlClass = await AddClassToDiagramAction.ExecuteAsync(command, ct);

        if (umlClass != null)
        {
            await Send.OkAsync(new(ClassId: umlClass.Id), ct);
        }
        else
        {
            // TODO: Handle failure case properly
            await Send.NoContentAsync(ct);
        }
    }
}
