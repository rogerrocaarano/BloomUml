using DiagramPersistenceServiceApi.Domain.Model;
using DiagramPersistenceServiceApi.Domain.Service;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Classes.GetClass;

public class GetClassAction : IAction<GetClassCommand, UmlClass>
{
    private readonly IDiagramsDomainService _diagramsDomainService;

    public GetClassAction(IDiagramsDomainService diagramsDomainService)
    {
        _diagramsDomainService = diagramsDomainService;
    }

    public async Task<UmlClass> ExecuteAsync(GetClassCommand command, CancellationToken ct)
    {
        return await _diagramsDomainService.GetClassAsync(command.ClassId, ct);
    }
}
