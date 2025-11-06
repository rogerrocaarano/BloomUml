using System;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Diagrams.GetDiagramsByOwner;

public class GetDiagramsByOwnerCommand : ICommand
{
    public Guid OwnerId { get; set; }

    public GetDiagramsByOwnerCommand(Guid ownerId)
    {
        OwnerId = ownerId;
    }
}
