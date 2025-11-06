using FastEndpoints;

namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Telemetry.HeartBeat;

public class HeartBeatEndpoint : EndpointWithoutRequest<HeartBeatDto.Response>
{
    public override void Configure()
    {
        Get("/telemetry/heartbeat");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await Send.OkAsync(
            new(TimeStamp: DateTime.UtcNow, ServiceName: "ClassDiagramBuilder.WebAPI"),
            ct
        );
    }
}
