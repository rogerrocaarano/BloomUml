using DiagramPersistenceServiceApi.Application.Actions.AddAttributeToClass;
using DiagramPersistenceServiceApi.Domain.Model;
using FastEndpoints;

namespace DiagramPersistenceServiceApi.Infrastructure.WebAPI.AddAttributeToClass;

public class AddAttributeToClassEndpoint
    : Endpoint<AddAttributeToClassDto.Request, AddAttributeToClassDto.Response>
{
    public required AddAttributeToClassAction AddAttributeToClassAction { get; set; }

    public override void Configure()
    {
        Post("classes/{ClassId}/attributes");
        // TODO: Add proper authentication and authorization
        AllowAnonymous();
    }

    public override async Task HandleAsync(AddAttributeToClassDto.Request req, CancellationToken ct)
    {
        var command = new AddAttributeToClassCommand(
            req.ClassId,
            req.Visibility,
            req.AttributeName,
            req.AttributeType
        );
        UmlAttribute? attribute = await AddAttributeToClassAction.ExecuteAsync(command, ct);

        if (attribute != null)
        {
            await Send.OkAsync(new(AttributeId: attribute.Id), ct);
        }
        else
        {
            // TODO: Handle failure case properly
            await Send.NoContentAsync(ct);
        }
    }
}
