namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Telemetry.HeartBeat;

public abstract class HeartBeatDto
{
    public record Response(DateTime TimeStamp, string ServiceName);
}
