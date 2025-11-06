using System;
using OpenDDD.Application;

namespace DiagramPersistenceServiceApi.Application.Actions.Diagrams.CreateDiagram;

public class CreateDiagramCommand : ICommand
{
    public Guid OwnerId { get; set; }
    public string DiagramName { get; set; }

    public CreateDiagramCommand(Guid ownerId, string diagramName)
    {
        OwnerId = ownerId;
        DiagramName = diagramName;
    }
}
