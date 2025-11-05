namespace Api.Features.Telemetry.HeartBeat;



public abstract class HeartBeatDto
{
    public record Response(
        DateTime TimeStamp,
        string ServiceName
    );
}