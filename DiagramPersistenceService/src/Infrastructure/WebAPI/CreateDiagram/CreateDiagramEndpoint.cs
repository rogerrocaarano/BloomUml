using DiagramPersistenceServiceApi.Application.Actions.CreateDiagram;
using DiagramPersistenceServiceApi.Domain.Model;
using FastEndpoints;

namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.CreateDiagram;

public class CreateDiagramEndpoint : Endpoint<CreateDiagramDto.Request, CreateDiagramDto.Response>
{
    public required CreateDiagramAction CreateDiagramAction { get; set; }

    public override void Configure()
    {
        Post("diagrams");
        // TODO: Add proper authentication and authorization
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateDiagramDto.Request req, CancellationToken ct)
    {
        var command = new CreateDiagramCommand(req.OwnerId, req.DiagramName);
        UmlDiagram? diagram = await CreateDiagramAction.ExecuteAsync(command, ct);

        if (diagram != null)
        {
            await Send.OkAsync(new(DiagramId: diagram.Id), ct);
        }
        else
        {
            // TODO: Handle failure case properly
            await Send.NoContentAsync(ct);
        }
    }
}
