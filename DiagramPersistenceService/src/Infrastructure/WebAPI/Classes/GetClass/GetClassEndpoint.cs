using DiagramPersistenceServiceApi.Application.Actions.Classes.GetClass;
using DiagramPersistenceServiceApi.Domain.Model;
using FastEndpoints;

namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Classes.GetClass;

public class GetClassEndpoint : Endpoint<EmptyRequest, GetClassDto.Response>
{
    public required GetClassAction GetClassAction { get; set; }

    public override void Configure()
    {
        Get("classes/{ClassId}");
        // TODO: Add proper authentication and authorization
        AllowAnonymous();
    }

    public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
    {
        var classId = Route<Guid>("ClassId");
        var command = new GetClassCommand(classId);
        UmlClass umlClass = await GetClassAction.ExecuteAsync(command, ct);

        var response = new GetClassDto.Response(
            ClassId: umlClass.Id,
            DiagramId: umlClass.DiagramId,
            Name: umlClass.Name,
            PositionX: umlClass.Position.X,
            PositionY: umlClass.Position.Y,
            Attributes: umlClass
                .Attributes.Select(a => new GetClassDto.AttributeResponse(
                    AttributeId: a.Id,
                    Visibility: a.Visibility.Value,
                    Name: a.Variable.Name,
                    Type: a.Variable.Type
                ))
                .ToList(),
            Methods: umlClass
                .Methods.Select(m => new GetClassDto.MethodResponse(
                    MethodId: m.Id,
                    Visibility: m.Visibility.Value,
                    Name: m.Name,
                    ReturnType: m.ReturnType
                ))
                .ToList()
        );

        await Send.OkAsync(response, ct);
    }
}
