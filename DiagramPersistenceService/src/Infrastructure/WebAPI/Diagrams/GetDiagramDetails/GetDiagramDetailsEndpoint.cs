using DiagramPersistenceServiceApi.Application.Actions.Diagrams.GetDiagramDetails;
using DiagramPersistenceServiceApi.Domain.Model;
using FastEndpoints;

namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Diagrams.GetDiagramDetails;

public class GetDiagramDetailsEndpoint : EndpointWithoutRequest<GetDiagramDetailsDto.Response>
{
    public required GetDiagramDetailsAction GetDiagramDetailsAction { get; set; }

    public override void Configure()
    {
        Get("diagrams/{DiagramId}/details");
        // TODO: Add proper authentication and authorization
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var diagramId = Route<Guid>("DiagramId");
        var command = new GetDiagramDetailsCommand(diagramId);
        UmlDiagram diagram = await GetDiagramDetailsAction.ExecuteAsync(command, ct);

        var response = new GetDiagramDetailsDto.Response(
            DiagramId: diagram.Id,
            OwnerId: diagram.OwnerId,
            Name: diagram.Name,
            Version: diagram.Version.Version,
            VersioningDateTime: diagram.Version.VersioningDateTime,
            ClassesIds: diagram.ClassesIds,
            RelationsIds: diagram.RelationsIds
        );

        await Send.OkAsync(response, ct);
    }
}
