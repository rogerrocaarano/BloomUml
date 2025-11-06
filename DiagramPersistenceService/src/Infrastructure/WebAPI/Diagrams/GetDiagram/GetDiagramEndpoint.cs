using DiagramPersistenceServiceApi.Application.Actions.Diagrams.GetDiagram;
using DiagramPersistenceServiceApi.Domain.Model;
using FastEndpoints;

namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Diagrams.GetDiagram;

public class GetDiagramEndpoint : EndpointWithoutRequest<GetDiagramDto.Response>
{
    public required GetDiagramAction GetDiagramAction { get; set; }

    public override void Configure()
    {
        Get("diagrams/{DiagramId}");
        // TODO: Add proper authentication and authorization
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var diagramId = Route<Guid>("DiagramId");
        var command = new GetDiagramCommand(diagramId);
        UmlDiagram diagram = await GetDiagramAction.ExecuteAsync(command, ct);

        var response = new GetDiagramDto.Response(
            DiagramId: diagram.Id,
            OwnerId: diagram.OwnerId,
            Name: diagram.Name,
            Version: diagram.Version.Version,
            VersioningDateTime: diagram.Version.VersioningDateTime
        );

        await Send.OkAsync(response, ct);
    }
}
