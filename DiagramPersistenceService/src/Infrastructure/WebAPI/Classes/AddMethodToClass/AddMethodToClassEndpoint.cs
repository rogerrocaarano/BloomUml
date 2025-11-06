using DiagramPersistenceServiceApi.Application.Actions.Classes.AddMethodToClass;
using DiagramPersistenceServiceApi.Domain.Model;
using FastEndpoints;

namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.Classes.AddMethodToClass;

public class AddMethodToClassEndpoint
    : Endpoint<AddMethodToClassDto.Request, AddMethodToClassDto.Response>
{
    public required AddMethodToClassAction AddMethodToClassAction { get; set; }

    public override void Configure()
    {
        Post("classes/{ClassId}/methods");
        // TODO: Add proper authentication and authorization
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddMethodToClassDto.Request req, CancellationToken ct)
    {
        var command = new AddMethodToClassCommand(
            req.ClassId,
            req.Visibility,
            req.MethodName,
            req.ReturnType
        );
        UmlMethod? method = await AddMethodToClassAction.ExecuteAsync(command, ct);

        if (method != null)
        {
            await Send.OkAsync(new(MethodId: method.Id), ct);
        }
        else
        {
            // TODO: Handle failure case properly
            await Send.NoContentAsync(ct);
        }
    }
}
