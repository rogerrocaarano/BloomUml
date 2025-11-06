using DiagramPersistenceServiceApi.Application.Actions.Diagrams.GetDiagramsByOwner;
using DiagramPersistenceServiceApi.Domain.Model;
using FastEndpoints;

namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Diagrams.GetDiagramsByOwner;

public class GetDiagramsByOwnerEndpoint : EndpointWithoutRequest<GetDiagramsByOwnerDto.Response>
{
    public required GetDiagramsByOwnerAction GetDiagramsByOwnerAction { get; set; }

    public override void Configure()
    {
        Get("diagrams/owner/{OwnerId}");
        // TODO: Add proper authentication and authorization
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var ownerId = Route<Guid>("OwnerId");
        var command = new GetDiagramsByOwnerCommand(ownerId);
        ICollection<UmlDiagram> diagrams = await GetDiagramsByOwnerAction.ExecuteAsync(command, ct);

        var diagramSummaries = diagrams
            .Select(d => new GetDiagramsByOwnerDto.DiagramSummary(
                DiagramId: d.Id,
                Name: d.Name,
                Version: d.Version.Version,
                VersioningDateTime: d.Version.VersioningDateTime
            ))
            .ToList();

        var response = new GetDiagramsByOwnerDto.Response(diagramSummaries);

        await Send.OkAsync(response, ct);
    }
}
